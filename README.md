# Capture The Flag
[![CTF](https://img.shields.io/badge/Capture%20The%20Flag-SA:MP-red)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/.NET%20Core-SampSharp.net-blue)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/GameMode-CSharp-yellow)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/Release-v6.5.8-green)](https://github.com/MrDave1999/Capture-the-flag)

Capture the flag is a gamemode for [SA-MP](https://www.sa-mp.com/) created with [sampsharp](https://github.com/ikkentim/SampSharp)

Capture the flag is a style of play in which two teams try to catch a flag and carry it to a certain location to score points.
To play, players are divided into two teams (Alpha and Beta), each on a field. To earn points, you must capture the flag and take it to a certain location.
Currently, the game mode consists of 20 maps and every 20 minutes a map change is made.

In this video you can find a demo of how the gamemode is looking: https://youtu.be/9Ban7Wkhqq4

## Main features

- The game mode has a total of 20 maps. Every 20 minutes the map will be changed.
- Every time you capture, recover and carry the flag, the player will earn a percentage of adrenaline. That "adrenaline" can be changed for some benefit with the `/combos` command or the H key. Some benefits that the player can redeem are: Invisibility, Jumps, Speed.
- You can create your own weapon pack with the `/weapons` command (or with the Y key). For each respawn, you will have the same weapons.
- You can remove a weapon from your weapon pack with the `/packet` command.
- The game mode has a killing sprees system. This way, players will know if any player has had a good killing streak.
- The game mode has a save system with MySQL 8.0. So that players can create their account and save their statistics.
- You can talk to your team members "privately" using the exclamation point (!).
  Example: `!hello guys`.
- The game mode has a basic VIP system with 3 levels: Silver, Gold and Premium.
- The game mode has a basic administration system with 4 levels: Assistant, Moderator, Administrator and Owner.
- Each player has their own rank. The gamemode has 15 ranks that are obtained for a certain amount of kills.
  You can see the available ranges with the `/ranks` command.
- You can see the top 10 players in terms of kills, deaths, dropped flags, headshots and killing sprees with the `/top` command.

## Installation

#### SA-MP CTF Server Download
- This package includes .NET Core (x86) for gamemode to work.

  - [SA-MP CTF Windows Server](https://github.com/MrDave1999/Capture-The-Flag/releases/download/6.5.8/Windows.Server.zip)
  - [SA-MP CTF Linux Server (x86)](https://github.com/MrDave1999/Capture-The-Flag/releases/download/6.5.8/Linux.Server.zip)

#### .NET Core Download 

  - [.NET Core Windows (x86)](https://download.visualstudio.microsoft.com/download/pr/11da2dd3-9946-49f4-9758-868dcfd9b479/5cc2813259ae85912c3484151637782e/dotnet-runtime-3.1.11-win-x86.exe)
  - [.NET Core Linux (x86)](https://deploy.timpotze.nl/packages/dotnet20200127.zip)

You will probably have to install two packages to be able to run gamemode on Linux: `libicu` and `libssl`.

Example in Ubuntu:
```
sudo apt-get install libssl1.0.0:i386
sudo apt-get install libicu-dev:i386
```

## Build

If you want to rebuild the project from `0`, you should download these dependencies (or packages):

- [SampSharp.GameMode](https://www.nuget.org/packages/SampSharp.GameMode/0.9.1)
- [SampSharp.Streamer](https://www.nuget.org/packages/SampSharp.Streamer/0.9.0)
- [SampSharp.YSF](https://www.nuget.org/packages/SampSharp.YSF/0.1.0-beta1)
- [MySql.Data](https://www.nuget.org/packages/MySql.Data/8.0.22)
- [ini-parser-netcore](https://www.nuget.org/packages/ini-parser-netcore/3.0.0)

**Note:** You can also install the package from the `NuGet package manager` that Visual Studio brings.

Some plugins you will need:

- [YSF-Lite](https://gitlab.com/critical99/ysf/-/releases)
- [Streamer](https://github.com/samp-incognito/samp-streamer-plugin/releases)
- [SampSharp](https://github.com/ikkentim/SampSharp/releases)

**Note:** Each plugin goes in the `plugins` folder.

The .NET Core Runtime should be added in the `CaptureTheFlag/runtimes` folder.

## Frequently Asked Questions

#### How do I edit the connection string?

Go to the [CaptureTheFlag.dll.config](https://github.com/MrDave1999/Capture-The-Flag/blob/main/CaptureTheFlag/CaptureTheFlag/bin/Debug/netcoreapp3.1/CaptureTheFlag.dll.config#L5) file and modify the `connectionString` tag.

#### How can I become an administrator on the server?

Go to the [config_server.ini](https://github.com/MrDave1999/Capture-The-Flag/blob/main/CaptureTheFlag/CaptureTheFlag/bin/Debug/netcoreapp3.1/scriptfiles/config_server.ini#L4) file and modify the `hidden command`, then log in to the server and type the command.

#### How do I change the length of the game?

Go to the [config_map.ini](https://github.com/MrDave1999/Capture-The-Flag/blob/main/CaptureTheFlag/CaptureTheFlag/bin/Debug/netcoreapp3.1/scriptfiles/config_maps.ini#L3) file and modify the `MAX_TIME_ROUND` property, the time must be expressed in "seconds".

## Images
![image](https://user-images.githubusercontent.com/43916038/114632050-6d19fa80-9c83-11eb-812e-0241a288564d.png)
![image](https://user-images.githubusercontent.com/43916038/114632071-77d48f80-9c83-11eb-9ff5-61609b64289e.png)

## Credits

- [ikkentim](https://github.com/ikkentim/SampSharp) by create SampSharp.
- [rickyah](https://github.com/rickyah/ini-parser) by create ini-parser.
- [Nickk888SAMP](https://github.com/Nickk888SAMP/TextDraw-Editor) by create NTD (TextDraw Editor).
- [samp-incognito](https://github.com/samp-incognito/samp-streamer-plugin) by create streamer-plugin.
- [MrDave1999](https://github.com/MrDave1999/Capture-The-Flag) by create gamemode.
- [Ts-Pytham](https://github.com/Ts-Pytham) for collaborating with the administration system.
- [critical99](https://gitlab.com/critical99/ysf) by create Lite version of IllidanS4 [YSF](https://github.com/IllidanS4/YSF).
- [BlasterDv](https://github.com/BlasterDv/SampSharp-YSF) by create Wrapper SampSharp.YSF of the YSF plugin.

### Mappers

- Area66 by DragonZafiro.
- d_dust5, SA_Hill and de_dust2_small by Elorreli.
- Compound by amirab. 
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
