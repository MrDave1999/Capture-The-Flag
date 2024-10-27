# Capture The Flag

![SA-MP logo](https://github.com/user-attachments/assets/dd12935e-5897-470b-ab06-a72b492a521c)
[![CTF](https://img.shields.io/badge/Capture%20The%20Flag-SA:MP-red)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/.NET%208.0-SampSharp.net-blue)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/GameMode-CSharp-yellow)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/Team%20Deathmatch-+Ranks-green)](https://github.com/MrDave1999/Capture-the-flag)
[![CTF](https://img.shields.io/badge/License-AGPL%203.0%20license-orange)](https://github.com/MrDave1999/Capture-the-flag)

This is a capture the flag for [SA-MP](https://www.sa-mp.mp) (San Andreas Multiplayer, a multiplayer mod for GTA San Andreas). There are 2 flags on the map, one for each team. Players need to capture the enemy's flag and bring it back to their own one.

## Index
- [About](#about)
- [Screenshots](#screenshots)
- [Technologies used](#technologies-used)
  - [Programming Languages](#programming-languages)
  - [Softwares](#softwares)
  - [Frameworks and libraries](#frameworks-and-libraries)
  - [Testing](#testing)
  - [Own libraries](#own-libraries)
- [Software Engineering](#software-engineering)
- [Installation](#installation)
- [Credentials](#credentials)
- [Supported RDBMS](#supported-rdbms)
- [Architectural overview](#architectural-overview)
- [Credits](#credits)
  - [Mappers](#mappers)
- [Contribution](#contribution)

## About

The Beta team plays against the Alpha team. The aim is to carry the enemy's flag to the spawn of the own flag. The own flag needs to be at the spawn to score. So you have to conquer the opponent's flag and defend your own team's one at the same time. It's necassary for the whole team to work together tactically to win.

The team which which got more points after x minutes wins. If both teams have the same points after the time is up, it's a draw. 

Beware! Enemies will see flag carriers on their radar as well!

In this video, you can watch a gameplay demo: https://youtu.be/yrPtJBuqB14

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
- [Visual Studio 2022](https://visualstudio.microsoft.com)
- [vscode](https://github.com/microsoft/vscode)
- [MariaDB](https://github.com/mariadb)
- [SQLite](https://www.sqlite.org)
- [DB Browser for SQLite](https://sqlitebrowser.org)
- [HeidiSQL](https://github.com/HeidiSQL)
- [GitHub Actions](https://github.com/actions)
- [Git](https://git-scm.com)
- [Docker](https://github.com/docker)

### Frameworks and libraries
- [.NET SDK 8.0](https://github.com/dotnet/runtime)
- [SampSharp](https://github.com/ikkentim/SampSharp)
- [samp-streamer-plugin](https://github.com/samp-incognito/samp-streamer-plugin)
- [SmartFormat](https://github.com/axuno/SmartFormat)
- [MySqlConnector](https://github.com/mysql-net/MySqlConnector)
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.SQLite)
- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection)
- [Microsoft.Extensions.Configuration.Binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder)
- [Microsoft.Extensions.Configuration.EnvironmentVariables](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.EnvironmentVariables)
- [BCrypt.Net-Next](https://github.com/BcryptNet/bcrypt.net)

### Testing
- [NUnit](https://github.com/nunit/nunit)
- [FluentAssertions](https://github.com/fluentassertions/fluentassertions)

### Own libraries
- [DotEnv.Core](https://github.com/MrDave1999/dotenv.core)
- [YeSql.Net](https://github.com/ose-net/yesql.net)
- [seztion-parser](https://github.com/MrDave1999/seztion-parser)

## Software Engineering

Software engineering concepts have been applied in this project:
- [Object-oriented programming](https://en.wikipedia.org/wiki/Object-oriented_programming)
- [Interface-based programming](https://en.wikipedia.org/wiki/Interface-based_programming)
- [Modular programming](https://en.wikipedia.org/wiki/Modular_programming)
- [Dependency injection](https://en.wikipedia.org/wiki/Dependency_injection)
- [Operation Result Pattern](https://medium.com/@wgyxxbf/result-pattern-a01729f42f8c)
- [Guard Clause](https://deviq.com/design-patterns/guard-clause)
- [Open-closed principle](https://en.wikipedia.org/wiki/Open%E2%80%93closed_principle)
- [Explicit dependencies](https://deviq.com/principles/explicit-dependencies-principle)
- [Separation of concerns](https://en.wikipedia.org/wiki/Separation_of_concerns)

## Installation

## Credentials

The following table shows the default credentials for authentication from the game mode.

| PlayerName              | Password                    |
|-------------------------|-----------------------------|
| Admin_Player            | 123456                      |
| Moderator_Player        | 123456                      |
| VIP_Player              | 123456                      |
| Basic_Player            | 123456                      |

## Supported RDBMS

- [MariaDB](https://github.com/mariadb)
- [SQLite](https://github.com/sqlite/sqlite)

You must specify the name of the database provider from the .env file.

Examples:
```sh
DatabaseProvider=MariaDB
```
Or also
```sh
DatabaseProvider=SQLite
```

If you choose to use MariaDB, you must specify the connection string in the .env file.
```sh
MariaDB__Server=localhost
MariaDB__Port=3306
MariaDB__Database=gamemode
MariaDB__UserName=root
MariaDB__Password=123456789
```
Or, if you choose to use SQLite, you must specify the location of the database file.
```sh
SQLite__DataSource=C:\Users\dave\OneDrive\Desktop\gamemode.db
```

See the [example .env file](https://github.com/MrDave1999/Capture-The-Flag/blob/dev/.env.example) for more information.

## Architectural overview

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