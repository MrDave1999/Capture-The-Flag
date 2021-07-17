# Capture The Flag
[![CTF](https://img.shields.io/badge/Capture%20The%20Flag-SA:MP-red)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/.NET%20Core-SampSharp.net-blue)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/GameMode-CSharp-yellow)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/Team%20DeathMatch-+Ranks-green)](https://github.com/MrDave1999/Capture-the-flag)

**Capture The Flag** is a gamemode for [SA-MP](https://www.sa-mp.com/) (San Andreas Multiplayer, a multiplayer mod for GTA San Andreas) created with [sampsharp](https://github.com/ikkentim/SampSharp).

Capture The Flag is a style of play in which two teams try to catch a flag and carry it to a certain location to score points.
To play, players are divided into two teams (Alpha and Beta), each on a field. To earn points, you must capture the flag and take it to a certain location.
Currently, the gamemode has more than 10 maps and every 20 minutes there is a map change.

In this video you can find a demo of how the gamemode is looking: https://youtu.be/yrPtJBuqB14

## Main features

- The gamemode has more than 10 maps. Every 20 minutes the map will be changed.
- Every time you capture, recover and carry the flag, the player will earn a percentage of adrenaline. That "adrenaline" can be changed for some benefit with the `/combos` command or the H key. Some benefits that the player can redeem are: Invisibility, Jumps, Speed.
- You can create your own weapon pack with the `/weapons` command (or with the Y key). For each respawn, you will have the same weapons.
- You can remove a weapon from your weapon pack with the `/packet` command.
- The gamemode has a killing sprees system. This way, players will know if any player has had a good killing streak.
- The gamemode has a save system with MySQL `8.0.22`. So that players can create their account and save their statistics.
- You can talk to your team members "privately" using the exclamation point (!).
  Example: `!hello guys`.
- The gamemode has a basic VIP system with 3 levels: Silver, Gold and Premium.
- The gamemode has a basic administration system with 4 levels: Assistant, Moderator, Administrator and Owner.
- Each player has their own rank. The gamemode has 15 ranks that are obtained for a certain amount of kills.
  You can see the available ranges with the `/ranks` command.
- You can see the top 10 players in terms of kills, deaths, dropped flags, headshots and killing sprees with the `/top` command.

## Installation

#### SA-MP CTF Server Download
- This package includes .NET Core 3.1 (x86) for gamemode to work.

  - [SA-MP CTF Windows Server](https://github.com/ctf-samp/Capture-The-Flag/releases/latest)
  - [SA-MP CTF Linux Server (x86)](https://github.com/ctf-samp/Capture-The-Flag/releases/latest)

#### .NET Core Download 

  - [.NET Core Windows (x86)](https://download.visualstudio.microsoft.com/download/pr/765b6839-9ee9-45f8-9aef-4bbea1aed51a/9dd5a72099788f4cc2b25b1e626f3356/dotnet-runtime-3.1.16-win-x86.exe)
  - [.NET Core Linux (x86)](https://deploy.timpotze.nl/packages/dotnet20200127.zip)

You will probably have to install two packages to be able to run gamemode on Linux: `libicu` and `libssl`.

Example in Ubuntu:
```
sudo apt-get install libssl1.0.0:i386
sudo apt-get install libicu-dev:i386
```
For more information, see the [wiki](https://github.com/ctf-samp/Capture-The-Flag/wiki).

## Build

I recommend that you install [Visual Studio 2019](https://visualstudio.microsoft.com/es/downloads/) to compile the project, if you are poor, use the community version which is free.

If you want to rebuild the project from zero, you should download these dependencies (or packages):

- [SampSharp.GameMode](https://www.nuget.org/packages/SampSharp.GameMode/0.9.1)
- [SampSharp.Streamer](https://www.nuget.org/packages/SampSharp.Streamer/0.9.0)
- [SampSharp.YSF](https://www.nuget.org/packages/SampSharp.YSF/0.1.0-beta1)
- [MySql.Data](https://www.nuget.org/packages/MySql.Data/8.0.22)
- [ini-parser-netcore](https://www.nuget.org/packages/ini-parser-netcore3.1/)

You can also install the package from the [NuGet package manager](https://www.nuget.org/downloads) that Visual Studio brings.

**Note:** You don't need to install the packages manually, I just mentioned it so you know which packages the project uses. Visual Studio is able to install the project's packages through NuGet and all thanks to the project's configuration file (.csproj).

Some plugins you will need (each plugin goes in the `plugins` folder):

- [YSF-Lite](https://gitlab.com/critical99/ysf/-/releases)
- [Streamer](https://github.com/samp-incognito/samp-streamer-plugin/releases)
- [SampSharp](https://github.com/ikkentim/SampSharp/releases)

You can also run the `samp-server.exe` from Visual Studio using the following `launchSettings.json` file (this file is actually created automatically by Visual Studio):
```json
{
  "profiles": {
    "CaptureTheFlag": {
      "commandName": "Executable",
      "executablePath": "C:\\Users\\syslan\\Desktop\\SA-MP\\Capture-The-Flag\\samp-server.exe",
      "workingDirectory": "C:\\Users\\syslan\\Desktop\\SA-MP\\Capture-The-Flag"
    }
  }
}
```
Of course, you must specify the path where `samp-server.exe` is located.

## Configuration

The server comes with two configuration files: [server.cfg.example](https://github.com/ctf-samp/Capture-The-Flag/blob/main/server.cfg.example) and [config.ini.example](https://github.com/ctf-samp/Capture-The-Flag/blob/main/scriptfiles/config.ini.example).

These files are example files, you will need to make a copy of the `server.cfg.example` file and rename it to `server.cfg`. Similarly with `config.ini.example`, you will need to make a copy and rename it to `config.ini`.

Remember that the files read by the SA-MP server are `server.cfg` and `config.ini`. 

Now you may wonder why you have to create two files manually, well, this is so that git doesn't track the changes in those files: `server.cfg` and `config.ini`.

## Frequently Asked Questions

#### How do I edit the connection string?

Go to the [config.ini](https://github.com/ctf-samp/Capture-The-Flag/blob/main/scriptfiles/config.ini.example#L9) file and modify the `CONNECTION_STRING` property.

#### How can I become an administrator on the server?

Go to the [config.ini](https://github.com/ctf-samp/Capture-The-Flag/blob/main/scriptfiles/config.ini.example#L4) file and modify the `HIDDEN_COMMAND`, then log in to the server and type the command.

#### How do I change the length of the game?

Go to the [config.ini](https://github.com/ctf-samp/Capture-The-Flag/blob/main/scriptfiles/config.ini.example#L12) file and modify the `MAX_TIME_ROUND` property, the time must be expressed in `seconds`.

#### How can I change the timeout when the map is loading?

Go to the [config.ini](https://github.com/ctf-samp/Capture-The-Flag/blob/main/scriptfiles/config.ini.example#L13) file and modify the `MAX_TIME_LOADING` property, the time must be expressed in `seconds`.

## Images
![image](https://user-images.githubusercontent.com/43916038/114632050-6d19fa80-9c83-11eb-812e-0241a288564d.png)
![image](https://user-images.githubusercontent.com/43916038/114632071-77d48f80-9c83-11eb-9ff5-61609b64289e.png)

## Credits

- [ikkentim](https://github.com/ikkentim/SampSharp) by create SampSharp.
- [rickyah](https://github.com/rickyah/ini-parser) by create ini-parser.
  - [MrDave1999 forked](https://github.com/mrdave1999/ini-parser) the original repository and released a version for `.NET Core 3.1` and added new functionality without altering the existing parser.
- [Nickk888SAMP](https://github.com/Nickk888SAMP/TextDraw-Editor) by create NTD (TextDraw Editor).
- [samp-incognito](https://github.com/samp-incognito/samp-streamer-plugin) by create streamer-plugin.
- [MrDave1999](https://github.com/MrDave1999/Capture-The-Flag) by create gamemode.
- [Ts-Pytham](https://github.com/Ts-Pytham) for collaborating with the administration system.
- [critical99](https://gitlab.com/critical99/ysf) by create Lite version of IllidanS4 [YSF](https://github.com/IllidanS4/YSF).
- [BlasterDv](https://github.com/BlasterDv/SampSharp-YSF) by create Wrapper SampSharp.YSF of the YSF plugin.

### Mappers

- Area66 by DragonZafiro.
- d_dust5, SA_Hill, de_aztec and de_dust2_small by Elorreli.
- Compound and cs_rockwar by Amirab. 
- DesertGlory and de_dust2_x3 by TheYoungCapone.
- EntryMap and TheConstruction by B4MB1[MC].
- fy_iceworld by Sleyer.
- fy_snow by UnuAlex.
- fy_snow2 by mihaibr.
- de_dust2 by JamesT85.
- Aim_Headshot by haubitze.
- Aim_Headshot2 by Niktia_Ruchkov.
- de_dust2_x1 by SpikY_.
- de_dust2_x2 by Amads.
- WarZone by Samarchai.
- cs_assault by Ghost-X.
- GateToHell and TheWild by Zniper.
- TheBunker by Dr.Pawno.
- cs_deagle5 by SENiOR.
- mp_jetdoor by saawan.
- Simpson by Risq.
- ZM_Italy - Unknown.
- zone_paintball by Famous.
- mp_island by Leo.