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

## Deployment with Docker

**1.** Copy the contents of `.env.example` to `.env`:

**On Linux:**
```sh
cp .env.example .env
```
**On Windows:**
```sh
copy .env.example .env
```

**2.** Build the image and initiate services:
```sh
docker-compose up --build -d
```
**3.** Add the server IP in your SA-MP client:
```
localhost:7777
```

## Frequently Asked Questions

#### How do I edit the connection string?

Go to the `.env` file and modify the `CONNECTION_STRING` key.

#### How can I become an administrator on the server?

Go to the `.env` file and modify the `HIDDEN_COMMAND` key, then log in in to the server and type the command.

#### How do I change the length of the game?

Go to the `.env` file and modify the `MAX_TIME_ROUND` key, the time must be expressed in `seconds`.

#### How can I change the timeout when the map is loading?

Go to the `.env` file and modify the `MAX_TIME_LOADING` key, the time must be expressed in `seconds`.

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
- [IllidanS4](https://github.com/IllidanS4/YSF) by create YSF-plugin.
- [BlasterDv](https://github.com/BlasterDv/SampSharp-YSF) by create Wrapper SampSharp.YSF of the YSF plugin.

### Mappers

- Area66 by DragonZafiro.
- d_dust5, SA_Hill, de_aztec and de_dust2_small by Elorreli.
- Compound and cs_rockwar by Amirab. 
- DesertGlory, fy_iceworld2 and de_dust2_x3 by TheYoungCapone.
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
