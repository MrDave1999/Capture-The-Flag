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
# Download SA-MP server and dotnet linux-x86 
#
FROM ubuntu:20.04 AS tools
RUN apt-get update && apt-get install -y --no-install-recommends wget

WORKDIR /sampserver
RUN wget https://gta-multiplayer.cz/downloads/samp037svr_R2-2-1.tar.gz --no-check-certificate \
    && tar -xf samp037svr_R2-2-1.tar.gz \
    && rm -f samp037svr_R2-2-1.tar.gz
WORKDIR /sampserver/samp03
RUN rm -rf filterscripts gamemodes include npcmodes scriptfiles server.cfg

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
    && rm -rf /var/lib/apt/lists/*

COPY ["gamemodes/*.amx", "gamemodes/"]
COPY ["filterscripts/*.amx", "filterscripts/"]
COPY ["plugins/*.so", "plugins/"]
COPY ["codepages/*.txt", "codepages/"]
COPY ["server.cfg.example", "server.cfg"]
COPY --from=tools /runtime runtime
COPY --from=tools /sampserver/samp03 .
RUN echo "" >> server.cfg \ 
    && echo "coreclr runtime" >> server.cfg \
    && echo "gamemode bin/CTF.Host.dll" >> server.cfg
COPY --from=build /app/out bin