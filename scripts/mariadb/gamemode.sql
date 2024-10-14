/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

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

/*!40000 ALTER TABLE `players` DISABLE KEYS */;
/*!40000 ALTER TABLE `players` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
