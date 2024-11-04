# Capture The Flag

![SA-MP logo](https://github.com/user-attachments/assets/dd12935e-5897-470b-ab06-a72b492a521c)

<p align="center">
  <a href="https://github.com/MrDave1999/Capture-The-Flag">
    <img src="https://img.shields.io/badge/Capture%20The%20Flag-SA:MP-red" />
  </a>
  <a href="https://github.com/MrDave1999/Capture-The-Flag">
    <img src="https://img.shields.io/badge/.NET%208.0-SampSharp.net-blue" />
  </a>
  <a href="https://github.com/MrDave1999/Capture-The-Flag">
    <img src="https://img.shields.io/badge/GameMode-CSharp-yellow" />
  </a>
  <a href="https://github.com/MrDave1999/Capture-The-Flag">
    <img src="https://img.shields.io/badge/Team%20Deathmatch-+Ranks-green" />
  </a>
  <a href="https://github.com/MrDave1999/Capture-The-Flag">
    <img src="https://img.shields.io/badge/License-AGPL%203.0%20license-orange" />
  </a>
</p>

<p align="center">
  <a href="https://github.com/MrDave1999/Capture-The-Flag">
    <img src="https://github.com/user-attachments/assets/2991265d-4626-4da5-839d-58a7ba2042e7" />
  </a>
</p>

**Capture The Flag** is a game mode for [SA-MP](https://www.sa-mp.mp) (San Andreas Multiplayer, a multiplayer mod for GTA San Andreas) created with [SampSharp](https://github.com/ikkentim/SampSharp).
There are 2 flags on the map, one for each team. Players need to capture the enemy's flag and bring it back to their own one.

## Index
- [Gameplay](#gameplay)
- [Screenshots](#screenshots)
- [Technologies used](#technologies-used)
  - [Programming Languages](#programming-languages)
  - [Softwares](#softwares)
  - [Frameworks and libraries](#frameworks-and-libraries)
  - [Testing](#testing)
- [Software Engineering](#software-engineering)
- [Requirements to play](#requirements-to-play)
- [Deployment without Docker](#deployment-without-docker)
- [Deployment with Docker](#deployment-with-docker)
- [Credentials](#credentials)
- [Supported RDBMS](#supported-rdbms)
  - [SQLite](#sqlite)
  - [MariaDB](#mariadb)
- [Architectural overview](#architectural-overview)
- [Credits](#credits)
  - [Mappers](#mappers)
- [Contribution](#contribution)

## Gameplay

The Beta team plays against the Alpha team. The aim is to carry the enemy's flag to the spawn of the own flag. The own flag needs to be at the spawn to score. So you have to conquer the opponent's flag and defend your own team's one at the same time. It's necassary for the whole team to work together tactically to win.

The team which which got more points after 15 minutes wins. If both teams have the same points after the time is up, it's a draw. 

Beware! Enemies will see flag carriers on their radar as well!

In this video, you can watch a gameplay demo: https://youtu.be/rsWCZaT4aBE or also see the [play list](https://www.youtube.com/playlist?list=PLBM-9TMXSAJjsWn4zmg1ua7eof9Aj83fS).

## Screenshots

<details>
<summary>sa-mp-000</summary>

![sa-mp-000](https://github.com/MrDave1999/Capture-The-Flag/blob/dev/screenshots/sa-mp-000.png)
</details>

<details>
<summary>sa-mp-001</summary>

![sa-mp-001](https://github.com/MrDave1999/Capture-The-Flag/blob/dev/screenshots/sa-mp-001.png)
</details>

<details>
<summary>sa-mp-002</summary>

![sa-mp-002](https://github.com/MrDave1999/Capture-The-Flag/blob/dev/screenshots/sa-mp-002.png)
</details>

<details>
<summary>sa-mp-003</summary>

![sa-mp-003](https://github.com/MrDave1999/Capture-The-Flag/blob/dev/screenshots/sa-mp-003.png)
</details>

<details>
<summary>sa-mp-004</summary>

![sa-mp-004](https://github.com/MrDave1999/Capture-The-Flag/blob/dev/screenshots/sa-mp-004.png)
</details>

## Technologies used

### Programming Languages
- [C Sharp](https://github.com/dotnet/csharplang)
- [Pawn](https://github.com/compuphase/pawn)

### Softwares
- [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools)
- [SA-MP Server](https://www.sa-mp.mp/downloads)
- [CompileApp-FS](https://github.com/MrDave1999/CompileApp-FS)
- [Visual Studio 2022](https://visualstudio.microsoft.com)
- [vscode](https://github.com/microsoft/vscode)
- [MariaDB](https://github.com/mariadb)
- [SQLite](https://www.sqlite.org)
- [DB Browser for SQLite](https://sqlitebrowser.org)
- [HeidiSQL](https://github.com/HeidiSQL)
- [GitHub Actions](https://github.com/actions)
- [Git](https://git-scm.com)
- [draw.io](https://app.diagrams.net)
- [Docker](https://github.com/docker)

### Frameworks and libraries
- [.NET SDK 8.0](https://github.com/dotnet/runtime)
- [SampSharp](https://github.com/ikkentim/SampSharp)
- [SampSharp-streamer](https://github.com/ikkentim/SampSharp-streamer)
- [samp-streamer-plugin](https://github.com/samp-incognito/samp-streamer-plugin)
- [SmartFormat](https://github.com/axuno/SmartFormat)
- [MySqlConnector](https://github.com/mysql-net/MySqlConnector)
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.SQLite)
- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection)
- [Microsoft.Extensions.Configuration.Binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder)
- [Microsoft.Extensions.Configuration.EnvironmentVariables](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.EnvironmentVariables)
- [BCrypt.Net-Next](https://github.com/BcryptNet/bcrypt.net)
- [DotEnv.Core](https://github.com/MrDave1999/dotenv.core)
- [YeSql.Net](https://github.com/ose-net/yesql.net)
- [seztion-parser](https://github.com/MrDave1999/seztion-parser)

### Testing
- [NUnit](https://github.com/nunit/nunit)
- [Fluent Assertions](https://github.com/fluentassertions/fluentassertions)

## Software Engineering

Software engineering concepts have been applied in this project:
- [Entity–component–system (ECS)](https://en.wikipedia.org/wiki/Entity_component_system)
- [Object-oriented programming](https://en.wikipedia.org/wiki/Object-oriented_programming)
- [Interface-based programming](https://en.wikipedia.org/wiki/Interface-based_programming)
- [Modular programming](https://en.wikipedia.org/wiki/Modular_programming)
- [Dependency injection](https://en.wikipedia.org/wiki/Dependency_injection)
- [Operation Result Pattern](https://medium.com/@wgyxxbf/result-pattern-a01729f42f8c)
- [Guard Clause](https://deviq.com/design-patterns/guard-clause)
- [Open-closed principle](https://en.wikipedia.org/wiki/Open%E2%80%93closed_principle)
- [Explicit dependencies](https://deviq.com/principles/explicit-dependencies-principle)
- [Separation of concerns](https://en.wikipedia.org/wiki/Separation_of_concerns)

## Requirements to play

- You must have **DirectX 9** installed on your local machine.
- You must download **Grand Theft Auto: San Andreas** on your local machine.
- You must download the [SA-MP client](https://www.sa-mp.mp/downloads) or the [open.mp launcher](https://github.com/openmultiplayer/launcher/releases) to connect to the servers.

## Deployment without Docker

- You must download [Visual C++ Redistributable x86](https://www.microsoft.com/en-us/download/details.aspx?id=48145) to load plugins such as SampSharp and Streamer.
- You need to download the [ctf-gamemode-windows.zip](https://github.com/MrDave1999/Capture-The-Flag/releases/latest) file that contains the files to run the game mode.
- Once downloaded, modify the `.env` file according to your needs.
- Run the `samp-server.exe`.

## Deployment with Docker

- Clone the repository:
```sh
git clone https://github.com/MrDave1999/Capture-The-Flag.git
```
- Change directory:
```sh
cd Capture-The-Flag
```
- Copy the contents of `.env.example` to `.env`:
```sh
cp .env.example .env
```
- Build the image and initiate services:
```sh
docker compose up --build -d
```
- Add the server IP in your [SA-MP client](https://www.sa-mp.mp/downloads):
```
localhost:7777
```

## Credentials

The following table shows the default credentials for authentication from the game mode.

| PlayerName              | Password                    |
|-------------------------|-----------------------------|
| Admin_Player            | 123456                      |
| Moderator_Player        | 123456                      |
| VIP_Player              | 123456                      |
| Basic_Player            | 123456                      |

Note that these credentials are only available if your database provider is **in-memory**. In your .env file you must indicate it as follows.
```sh
DatabaseProvider=InMemory
```

## Supported RDBMS

### SQLite

- Download sqlite3 CLI from [here](https://www.sqlite.org/download.html) (select the file named **sqlite-tools-win-x86**).
- Create a file called `.env` in the root directory:
```sh
copy .env.example .env
```
- You must specify the name of the database provider from the .env file:
```sh
DatabaseProvider=SQLite
```
- You must specify the location of the database file:
```sh
SQLite__DataSource=C:\Users\mrdave\OneDrive\Desktop\gamemode.db
```
- Finally, you must import the database:
```sh
sqlite3 gamemode.db < ./scripts/sqlite/gamemode.sql
```
See the [scripts](https://github.com/MrDave1999/Capture-The-Flag/tree/dev/scripts) for more information.

### MariaDB

- Install [MariaDb Server](https://mariadb.org/download) and set up your username and password.
- Create a file called `.env` in the root directory:
```sh
copy .env.example .env
```
- You must specify the name of the database provider from the .env file:
```sh
DatabaseProvider=MariaDB
```
- You must specify the connection string in the .env file:
```sh
MariaDB__Server=localhost
MariaDB__Port=3306
MariaDB__Database=gamemode
MariaDB__UserName=root
MariaDB__Password=123456789
```
- Finally, you must import the database:
```sh
mariadb -uroot -p123456789 gamemode < ./scripts/mariadb/gamemode.sql
```
See the [scripts](https://github.com/MrDave1999/Capture-The-Flag/tree/dev/scripts) for more information.

## Architectural overview

<details>
<summary><b>Show diagram</b></summary>

![overview](https://github.com/MrDave1999/Capture-The-Flag/blob/dev/screenshots/architectural-overview.png)

</details>

### Main components
- **Application Core.** Contains all the logic of the game called "Capture The Flag", including the rules and procedures that define how the game is played.
- **Persistence layer.** Contains all data access logic. The purpose of this layer is to prevent the filtering of data access logic in the application core.
- **Host Application.** Contains everything needed to run the game mode. It represents the entry point of the application.
  This layer performs other tasks such as:
  - Load application settings from `.env` file.
  - Select the database provider.
  - Register services to DI Container.
  - Add systems to the services collection.
  - Enable desired ECS system features.

## Credits

- [MrDave1999](https://github.com/MrDave1999/Capture-The-Flag) for creating the "Capture The Flag" game mode.
- [ikkentim](https://github.com/ikkentim/SampSharp) for creating the SampSharp framework.
- [Nickk888SAMP](https://github.com/Nickk888SAMP/TextDraw-Editor) for creating NTD (TextDraw Editor).
- [samp-incognito](https://github.com/samp-incognito/samp-streamer-plugin) for creating the streamer-plugin.

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

## Contribution

Any contribution is welcome! Remember that you can contribute not only in the code, but also in the documentation or even improve the tests.

Follow the steps below:

- Fork it
- Create your custom branch (git checkout -b my-new-change)
- Commit your changes (git commit -am 'Add some change')
- Push to the branch (git push origin my-new-change)
- Create new Pull Request