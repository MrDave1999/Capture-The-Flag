#
# Build stage/image
#
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY *.sln .
COPY *.props .

# Copy csproj and restore as distinct layers
COPY ["src/Host/*.csproj", "src/Host/"]
COPY ["src/Application/*.csproj", "src/Application/"]
COPY ["src/Persistence/Persistence.InMemory/*.csproj", "src/Persistence/Persistence.InMemory/"]
COPY ["src/Persistence/Persistence.MariaDB/*.csproj", "src/Persistence/Persistence.MariaDB/"]
COPY ["src/Persistence/Persistence.SQLite/*.csproj", "src/Persistence/Persistence.SQLite/"]
COPY ["src/Persistence/*.props", "src/Persistence/"]
RUN dotnet restore

# Copy everything else and build
COPY ["src/", "."]
RUN dotnet publish -c Release -o out --no-restore

#
# Download SA-MP server and dotnet linux-x86 
#
FROM ubuntu:20.04 AS tools
RUN apt-get update && apt-get install -y --no-install-recommends wget

WORKDIR /samp-server
RUN wget https://gta-multiplayer.cz/downloads/samp037svr_R2-2-1.tar.gz --no-check-certificate \
    && tar -xf samp037svr_R2-2-1.tar.gz \
    && rm -f samp037svr_R2-2-1.tar.gz
COPY ["samp037svr_R2-2-1/samp03/", "."]
RUN rm -rf filterscripts gamemodes include npcmodes scriptfiles server.cfg

WORKDIR /dotnet-runtime
RUN wget https://github.com/Servarr/dotnet-linux-x86/releases/download/v8.0.4-90/dotnet-runtime-8.0.4-linux-x86.tar.gz --no-check-certificate \
    && tar -xf dotnet-runtime-8.0.4-linux-x86.tar.gz \
    && rm -f dotnet-runtime-8.0.4-linux-x86.tar.gz
COPY ["dotnet-runtime-8.0.4-linux-x86/shared/Microsoft.NETCore.App/8.0.4/", "."]

#
# Final stage/image
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
    && rm -rf /var/lib/apt/lists/*

COPY ["gamemodes/*.amx", "gamemodes/"]
COPY ["filterscripts/*.amx", "filterscripts/"]
COPY ["plugins/*.so", "plugins/"]
COPY ["scriptfiles", "scriptfiles/"]
COPY ["server.cfg.example", "server.cfg"]
COPY --from=tools /dotnet-runtime dotnet-runtime
COPY --from=tools /samp-server .
RUN echo "coreclr dotnet-runtime" >> server.cfg \
    && echo "gamemode bin/CTF.Host.dll" >> server.cfg

COPY --from=build /app/out bin