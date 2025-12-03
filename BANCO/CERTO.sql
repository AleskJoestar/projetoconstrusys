-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: construsys
-- ------------------------------------------------------
-- Server version	8.3.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `construcao`
--

DROP TABLE IF EXISTS `construcao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `construcao` (
  `id_const` int NOT NULL AUTO_INCREMENT,
  `nome_projeto_const` varchar(255) NOT NULL,
  `localizacao_const` varchar(255) DEFAULT NULL,
  `id_proprietario_fk` int NOT NULL,
  PRIMARY KEY (`id_const`),
  KEY `id_proprietario_fk` (`id_proprietario_fk`),
  CONSTRAINT `construcao_ibfk_1` FOREIGN KEY (`id_proprietario_fk`) REFERENCES `proprietario` (`id_proprietario`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `construcao`
--

LOCK TABLES `construcao` WRITE;
/*!40000 ALTER TABLE `construcao` DISABLE KEYS */;
/*!40000 ALTER TABLE `construcao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `construcaomaterial`
--

DROP TABLE IF EXISTS `construcaomaterial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `construcaomaterial` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_construcao` int NOT NULL,
  `id_material` int NOT NULL,
  `quantidade_const_mat` float NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id_construcao` (`id_construcao`),
  KEY `id_material` (`id_material`),
  CONSTRAINT `construcaomaterial_ibfk_1` FOREIGN KEY (`id_construcao`) REFERENCES `construcao` (`id_const`) ON DELETE CASCADE,
  CONSTRAINT `construcaomaterial_ibfk_2` FOREIGN KEY (`id_material`) REFERENCES `material` (`id_material`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `construcaomaterial`
--

LOCK TABLES `construcaomaterial` WRITE;
/*!40000 ALTER TABLE `construcaomaterial` DISABLE KEYS */;
/*!40000 ALTER TABLE `construcaomaterial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `despesa`
--

DROP TABLE IF EXISTS `despesa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `despesa` (
  `id_despesa` int NOT NULL AUTO_INCREMENT,
  `descricao_desp` varchar(255) NOT NULL,
  `valor_desp` float NOT NULL,
  `data_desp` date NOT NULL,
  `id_const_fk` int DEFAULT NULL,
  `id_forne_fk` int DEFAULT NULL,
  PRIMARY KEY (`id_despesa`),
  KEY `id_const_fk` (`id_const_fk`),
  KEY `id_forne_fk` (`id_forne_fk`),
  CONSTRAINT `despesa_ibfk_1` FOREIGN KEY (`id_const_fk`) REFERENCES `construcao` (`id_const`) ON DELETE CASCADE,
  CONSTRAINT `despesa_ibfk_2` FOREIGN KEY (`id_forne_fk`) REFERENCES `fornecedor` (`id_forne`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `despesa`
--

LOCK TABLES `despesa` WRITE;
/*!40000 ALTER TABLE `despesa` DISABLE KEYS */;
/*!40000 ALTER TABLE `despesa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fornecedor`
--

DROP TABLE IF EXISTS `fornecedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fornecedor` (
  `id_forne` int NOT NULL AUTO_INCREMENT,
  `nome_forne` varchar(255) NOT NULL,
  `contato_forne` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_forne`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fornecedor`
--

LOCK TABLES `fornecedor` WRITE;
/*!40000 ALTER TABLE `fornecedor` DISABLE KEYS */;
/*!40000 ALTER TABLE `fornecedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mao_de_obra`
--

DROP TABLE IF EXISTS `mao_de_obra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mao_de_obra` (
  `id_mao_de_obra` int NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) NOT NULL,
  `custo` float NOT NULL,
  `id_const_fk` int NOT NULL,
  PRIMARY KEY (`id_mao_de_obra`),
  KEY `id_const_fk` (`id_const_fk`),
  CONSTRAINT `mao_de_obra_ibfk_1` FOREIGN KEY (`id_const_fk`) REFERENCES `construcao` (`id_const`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mao_de_obra`
--

LOCK TABLES `mao_de_obra` WRITE;
/*!40000 ALTER TABLE `mao_de_obra` DISABLE KEYS */;
/*!40000 ALTER TABLE `mao_de_obra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `material`
--

DROP TABLE IF EXISTS `material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `material` (
  `id_material` int NOT NULL AUTO_INCREMENT,
  `nome_material` varchar(255) NOT NULL,
  `unidade_material` varchar(50) NOT NULL,
  PRIMARY KEY (`id_material`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `material`
--

LOCK TABLES `material` WRITE;
/*!40000 ALTER TABLE `material` DISABLE KEYS */;
/*!40000 ALTER TABLE `material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proprietario`
--

DROP TABLE IF EXISTS `proprietario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proprietario` (
  `id_proprietario` int NOT NULL AUTO_INCREMENT,
  `nome_proprietario` varchar(255) NOT NULL,
  `email_proprietario` varchar(255) NOT NULL,
  PRIMARY KEY (`id_proprietario`),
  UNIQUE KEY `email_proprietario` (`email_proprietario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proprietario`
--

LOCK TABLES `proprietario` WRITE;
/*!40000 ALTER TABLE `proprietario` DISABLE KEYS */;
INSERT INTO `proprietario` VALUES (1,'Cleverson','cleber@cleversondutra.info');
/*!40000 ALTER TABLE `proprietario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-12-02 20:07:26
