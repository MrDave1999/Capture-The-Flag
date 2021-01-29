# Capture The Flag
[![CTF](https://img.shields.io/badge/Capture%20The%20Flag-SA:MP-red)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/.NET%20Core-SampSharp.net-blue)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/GameMode-CSharp-yellow)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/Release-v6.1.4-green)](https://github.com/MrDave1999/Capture-the-flag)

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

## Installation

#### SA-MP CTF Server Download
- This package includes .NET Core (x86) for gamemode to work.

  - [SA-MP CTF Windows Server](https://github.com/MrDave1999/Capture-The-Flag/releases/download/6.1.4/Windows.Server.zip)
  - [SA-MP CTF Linux Server (x86)](https://github.com/MrDave1999/Capture-The-Flag/releases/download/6.1.4/Linux.Server.zip)

#### .NET Core Download 

  - [.NET Core Windows (x86)](https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-3.1.11-windows-x86-installer)
  - [.NET Core Linux (x86)](https://deploy.timpotze.nl/packages/dotnet20200127.zip)

## Images

![img1](https://i.ibb.co/6Fm35n8/sa-mp-000.png)
![img2](https://i.ibb.co/WKXyxdn/sa-mp-001.png)
![img3](https://i.ibb.co/560HSpP/sa-mp-002.png)
![img4](https://i.ibb.co/6JGVFk8/sa-mp-003.png)
![img5](https://i.ibb.co/bNd0P65/sa-mp-004.png)

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
