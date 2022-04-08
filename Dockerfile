#
# Build app
#
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/*.csproj .
RUN dotnet restore

# Copy everything else and build
COPY src .
RUN dotnet publish -c Release -o out

#
# Install SA-MP server with samptcl
#
FROM southclaws/sampctl AS samp-server
WORKDIR /sampserver

COPY pawn.json .
RUN sampctl package ensure \
    && rm -rf dependencies

COPY include include
COPY filterscripts filterscripts
COPY build-filterscripts.sh .
RUN chmod u+x build-filterscripts.sh
RUN ["./build-filterscripts.sh"]
RUN rm -rf include \
    pawn.json \
    build-filterscripts.sh

WORKDIR /sampserver/filterscripts
# Delete all directories except .amx files
RUN rm -rf */

#
# Get .NET 6 Runtime x86
#
FROM ubuntu:20.04 AS net-runtime
WORKDIR /dotnet

RUN apt-get update && apt-get install -y --no-install-recommends wget

RUN wget https://deploy.timpotze.nl/packages/runtime_603_20220324.tar.gz --no-check-certificate \
    && tar -xf runtime_603_20220324.tar.gz \
    && rm -f runtime_603_20220324.tar.gz

# 
# Build runtime image
#
FROM ubuntu:20.04
WORKDIR /app
EXPOSE 7777/udp

RUN dpkg --add-architecture i386
RUN apt-get update && apt-get install -y --no-install-recommends \
    libc6:i386 \
    libstdc++6:i386 \
    libssl1.1:i386 \
    libicu-dev:i386 \
    tzdata \
    && rm -rf /var/lib/apit/lists/*

COPY gamemodes gamemodes
COPY wait-for-it.sh .
RUN chmod u+x wait-for-it.sh

COPY --from=net-runtime /dotnet dotnet
COPY --from=samp-server /sampserver .
RUN echo "coreclr dotnet/runtime" >> server.cfg \
    && echo "gamemode bin/CaptureTheFlag.dll" >> server.cfg

COPY scriptfiles scriptfiles
COPY --from=build-env /app/out bin