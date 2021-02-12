use gamemode;

CREATE TABLE IF NOT EXISTS `players` (
accountNumber int not null auto_increment,
namePlayer varchar(20) not null,
pass varchar(64) not null,
totalKills int not null,
totalDeaths int not null,
killingSprees int not null,
levelGame int not null,
droppedFlags int not null,
headshots int not null,
registryDate datetime,
primary key(accountNumber),
INDEX(namePlayer)
);

CREATE TABLE IF NOT EXISTS `admins` (
namePlayer varchar(20) not null,
levelAdmin int not null,
primary key(namePlayer)
);

CREATE TABLE IF NOT EXISTS `vips` (
namePlayer varchar(20) not null,
levelVip int not null,
skinid int not null,
primary key(namePlayer)
);