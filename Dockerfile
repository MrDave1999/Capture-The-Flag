#
# Build stage/image
#
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY *.props .
# .NET 8.0 is required because the game mode uses C# 12.0.
COPY --from=mcr.microsoft.com/dotnet/sdk:8.0 /usr/share/dotnet /usr/share/dotnet

# Copy csproj and restore as distinct layers
COPY ["src/Host/*.csproj", "src/Host/"]
COPY ["src/Host/*.targets", "src/Host/"]
COPY ["src/Application/*.csproj", "src/Application/"]
COPY ["src/Persistence/Persistence.InMemory/*.csproj", "src/Persistence/Persistence.InMemory/"]
COPY ["src/Persistence/Persistence.MariaDB/*.csproj", "src/Persistence/Persistence.MariaDB/"]
COPY ["src/Persistence/Persistence.SQLite/*.csproj", "src/Persistence/Persistence.SQLite/"]
COPY ["src/Persistence/*.props", "src/Persistence/"]
WORKDIR /app/src/Host
RUN dotnet restore -p:TargetFramework=net6.0

# Copy everything else and build
COPY ["src/", "/app/src/"]
RUN dotnet publish --framework=net6.0 -c Release -o /app/out --no-restore

#
# Download open.mp server and dotnet linux-x86 
#
FROM ubuntu:22.04 AS tools
RUN apt-get update && apt-get install -y --no-install-recommends wget

WORKDIR /open-mp
ENV OPEN_MP_VERSION="1.3.1.2748"
RUN wget https://github.com/openmultiplayer/open.mp/releases/download/v${OPEN_MP_VERSION}/open.mp-linux-x86.tar.gz --no-check-certificate \
    && tar -xf open.mp-linux-x86.tar.gz \
    && rm -f open.mp-linux-x86.tar.gz
WORKDIR /open-mp/Server
RUN rm -rf filterscripts gamemodes include npcmodes scriptfiles config.json

WORKDIR /runtime
ENV TARGET_FRAMEWORK="6.0.35"
ENV VERSION="6.0.35-97"
RUN wget https://github.com/Servarr/dotnet-linux-x86/releases/download/v${VERSION}/dotnet-runtime-${TARGET_FRAMEWORK}-linux-x86.tar.gz --no-check-certificate \
    && mkdir runtime \
    && tar -xf dotnet-runtime-${TARGET_FRAMEWORK}-linux-x86.tar.gz -C runtime \
    && rm -f dotnet-runtime-${TARGET_FRAMEWORK}-linux-x86.tar.gz \
    && cp -rf runtime/shared/Microsoft.NETCore.App/${TARGET_FRAMEWORK}/** . \
    && rm -rf runtime

#
# Final stage/image
#
FROM ubuntu:22.04
WORKDIR /app
RUN dpkg --add-architecture i386
RUN apt-get update && apt-get install -y --no-install-recommends \
    libc6:i386 \
    libstdc++6:i386 \
    libssl3:i386 \
    libicu-dev:i386 \
    tzdata \
    && rm -rf /var/lib/apt/lists/*

COPY ["gamemodes/*.amx", "gamemodes/"]
COPY ["filterscripts/*.amx", "filterscripts/"]
COPY ["plugins/*.so", "plugins/"]
COPY ["codepages/*.txt", "codepages/"]
COPY ["server.cfg.example", "server.cfg"]
COPY --from=tools /runtime runtime
COPY --from=tools /open-mp/Server .
COPY --from=build /app/out bin