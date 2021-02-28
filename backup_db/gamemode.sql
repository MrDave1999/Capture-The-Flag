-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: gamemode
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admins` (
  `namePlayer` varchar(20) NOT NULL,
  `levelAdmin` int NOT NULL,
  PRIMARY KEY (`namePlayer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admins`
--

LOCK TABLES `admins` WRITE;
/*!40000 ALTER TABLE `admins` DISABLE KEYS */;
INSERT INTO `admins` VALUES ('[DRE]K3NDO_[LT]',2),('MrDave1999',4);
/*!40000 ALTER TABLE `admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `players`
--

DROP TABLE IF EXISTS `players`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `players` (
  `accountNumber` int NOT NULL AUTO_INCREMENT,
  `namePlayer` varchar(20) NOT NULL,
  `pass` varchar(64) NOT NULL,
  `totalKills` int NOT NULL,
  `totalDeaths` int NOT NULL,
  `killingSprees` int NOT NULL,
  `levelGame` int NOT NULL,
  `droppedFlags` int NOT NULL,
  `headshots` int NOT NULL,
  `registryDate` datetime DEFAULT NULL,
  PRIMARY KEY (`accountNumber`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `players`
--

LOCK TABLES `players` WRITE;
/*!40000 ALTER TABLE `players` DISABLE KEYS */;
INSERT INTO `players` VALUES (1,'MrDave1999','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',67,55,9,2,36,8,'2021-01-23 12:53:04'),(2,'Ts_Pytham','d9a31550033ee07d6e14302eea8202c07c266b633154513d817ca8bb91de40d1',16,10,4,1,12,1,'2021-01-31 20:55:52'),(3,'MrDeath','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',9,10,2,1,1,1,'2021-02-09 22:28:34'),(4,'BigBoss','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1,2,9,1,19,10,'2021-02-09 22:28:34'),(5,'[SK]KAIN','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',12,9,10,1,2,2,'2021-02-09 22:28:34'),(6,'[SK]Vago[L]','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',6,3,16,1,15,4,'2021-02-09 22:28:34'),(7,'[DRE]K3NDO_[LT]','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',18,18,16,1,7,7,'2021-02-09 22:28:34'),(8,'[DRE]DOBLE_ZETA','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',14,11,11,1,6,15,'2021-02-09 22:28:34'),(9,'Alejandro_Garcia','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',18,4,9,1,12,15,'2021-02-09 22:28:34'),(10,'REVENTADOR','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',17,1,15,1,13,1,'2021-02-09 22:28:34'),(11,'el.papi.chulo','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',4,0,7,1,14,12,'2021-02-09 22:28:34'),(12,'elpayaso_asesino','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',0,2,11,1,9,12,'2021-02-09 22:28:34'),(13,'Max_Stylees','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',14,15,14,1,3,16,'2021-02-09 22:28:34'),(14,'Dark.Net','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',4,11,4,1,0,1,'2021-02-10 11:18:14');
/*!40000 ALTER TABLE `players` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vips`
--

DROP TABLE IF EXISTS `vips`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vips` (
  `namePlayer` varchar(20) NOT NULL,
  `levelVip` int NOT NULL,
  `skinid` int NOT NULL,
  PRIMARY KEY (`namePlayer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vips`
--

LOCK TABLES `vips` WRITE;
/*!40000 ALTER TABLE `vips` DISABLE KEYS */;
INSERT INTO `vips` VALUES ('MrDave1999',3,-1);
/*!40000 ALTER TABLE `vips` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-02-11 17:33:39
