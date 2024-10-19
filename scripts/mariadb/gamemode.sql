CREATE DATABASE IF NOT EXISTS `gamemode` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `gamemode`;

CREATE TABLE IF NOT EXISTS `players` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `password` varchar(60) NOT NULL,
  `total_kills` int(11) NOT NULL,
  `total_deaths` int(11) NOT NULL,
  `max_killing_spree` int(11) NOT NULL,
  `brought_flags` int(11) NOT NULL,
  `captured_flags` int(11) NOT NULL,
  `dropped_flags` int(11) NOT NULL,
  `returned_flags` int(11) NOT NULL,
  `head_shots` int(11) NOT NULL,
  `role_id` enum('Basic','VIP','Moderator','Admin') NOT NULL,
  `skin_id` int(11) NOT NULL,
  `rank_id` int(11) NOT NULL,
  `created_at` datetime NOT NULL,
  `last_connection` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `ix_players_name` (`name`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;