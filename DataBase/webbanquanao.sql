-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: webbanhang
-- ------------------------------------------------------
-- Server version	8.0.43

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
-- Table structure for table `chitietdonhang`
--

DROP TABLE IF EXISTS `chitietdonhang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitietdonhang` (
  `MaChiTietDonHang` int NOT NULL AUTO_INCREMENT,
  `MaDonHang` int DEFAULT NULL,
  `MaChiTiet` int DEFAULT NULL,
  `SoLuong` int DEFAULT NULL,
  `Gia` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`MaChiTietDonHang`),
  KEY `MaDonHang` (`MaDonHang`),
  KEY `MaChiTiet` (`MaChiTiet`),
  CONSTRAINT `chitietdonhang_ibfk_1` FOREIGN KEY (`MaDonHang`) REFERENCES `donhang` (`MaDonHang`),
  CONSTRAINT `chitietdonhang_ibfk_2` FOREIGN KEY (`MaChiTiet`) REFERENCES `chitietsanpham` (`MaChiTiet`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitietdonhang`
--

LOCK TABLES `chitietdonhang` WRITE;
/*!40000 ALTER TABLE `chitietdonhang` DISABLE KEYS */;
INSERT INTO `chitietdonhang` VALUES (10,1,1,1,850000.00),(11,1,3,2,290000.00),(12,2,5,1,1200000.00),(13,5,14,1,290000.00),(14,6,27,1,350000.00),(15,7,24,1,350000.00),(16,8,26,1,350000.00),(17,9,26,1,350000.00),(18,10,24,1,350000.00),(19,11,24,1,350000.00),(20,12,24,1,350000.00),(21,13,10,1,290000.00),(22,14,23,1,350000.00),(23,15,25,1,350000.00),(24,16,24,1,350000.00),(25,17,11,1,290000.00),(26,18,17,1,290000.00),(27,19,24,1,350000.00),(28,20,24,1,350000.00),(29,23,23,1,350000.00);
/*!40000 ALTER TABLE `chitietdonhang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chitietgiohang`
--

DROP TABLE IF EXISTS `chitietgiohang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitietgiohang` (
  `MaChiTietGioHang` int NOT NULL AUTO_INCREMENT,
  `MaGiohang` int DEFAULT NULL,
  `MaChiTiet` int DEFAULT NULL,
  `SoLuong` int DEFAULT NULL,
  PRIMARY KEY (`MaChiTietGioHang`),
  KEY `MaGiohang` (`MaGiohang`),
  KEY `MaChiTiet` (`MaChiTiet`),
  CONSTRAINT `chitietgiohang_ibfk_1` FOREIGN KEY (`MaGiohang`) REFERENCES `giohang` (`MaGioHang`),
  CONSTRAINT `chitietgiohang_ibfk_2` FOREIGN KEY (`MaChiTiet`) REFERENCES `chitietsanpham` (`MaChiTiet`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitietgiohang`
--

LOCK TABLES `chitietgiohang` WRITE;
/*!40000 ALTER TABLE `chitietgiohang` DISABLE KEYS */;
INSERT INTO `chitietgiohang` VALUES (8,4,26,1),(9,5,27,2);
/*!40000 ALTER TABLE `chitietgiohang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chitietsanpham`
--

DROP TABLE IF EXISTS `chitietsanpham`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitietsanpham` (
  `MaChiTiet` int NOT NULL AUTO_INCREMENT,
  `MaSP` int DEFAULT NULL,
  `MaKichCo` int DEFAULT NULL,
  `MaMauSac` int DEFAULT NULL,
  `SoLuong` int DEFAULT NULL,
  PRIMARY KEY (`MaChiTiet`),
  KEY `MaSP` (`MaSP`),
  KEY `MaKichCo` (`MaKichCo`),
  KEY `MaMauSac` (`MaMauSac`),
  CONSTRAINT `chitietsanpham_ibfk_1` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`),
  CONSTRAINT `chitietsanpham_ibfk_2` FOREIGN KEY (`MaKichCo`) REFERENCES `kichco` (`MaKichCo`),
  CONSTRAINT `chitietsanpham_ibfk_3` FOREIGN KEY (`MaMauSac`) REFERENCES `mausac` (`MaMauSac`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitietsanpham`
--

LOCK TABLES `chitietsanpham` WRITE;
/*!40000 ALTER TABLE `chitietsanpham` DISABLE KEYS */;
INSERT INTO `chitietsanpham` VALUES (1,1,2,1,50),(2,1,3,1,30),(3,10,2,5,100),(4,30,3,3,40),(5,39,7,1,20),(6,1,2,1,50),(7,1,3,1,30),(8,10,2,5,100),(9,30,3,3,40),(10,39,7,1,20),(11,1,2,1,50),(12,1,3,1,30),(13,10,2,5,100),(14,30,3,3,40),(15,39,7,1,20),(16,1,2,1,50),(17,1,3,1,30),(18,10,2,5,100),(19,30,3,3,40),(20,39,7,1,20),(21,1,2,1,50),(22,1,3,1,30),(23,10,2,5,100),(24,30,3,3,40),(25,39,7,1,20),(26,1,2,1,50),(27,1,3,1,30),(28,10,2,5,100),(29,30,3,3,40),(30,39,7,1,20);
/*!40000 ALTER TABLE `chitietsanpham` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diachi`
--

DROP TABLE IF EXISTS `diachi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diachi` (
  `MaDiaChi` int NOT NULL AUTO_INCREMENT,
  `MaTK` int DEFAULT NULL,
  `HoTen` varchar(200) DEFAULT NULL,
  `Sdt` varchar(15) DEFAULT NULL,
  `DiaChiChiTiet` varchar(500) DEFAULT NULL,
  `LoaiDiaChi` varchar(100) DEFAULT NULL,
  `IsDefault` bit(1) DEFAULT b'0',
  PRIMARY KEY (`MaDiaChi`),
  KEY `MaTK` (`MaTK`),
  CONSTRAINT `diachi_ibfk_1` FOREIGN KEY (`MaTK`) REFERENCES `taikhoan` (`MaTK`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diachi`
--

LOCK TABLES `diachi` WRITE;
/*!40000 ALTER TABLE `diachi` DISABLE KEYS */;
INSERT INTO `diachi` VALUES (1,7,'Tri Nhânnn','0378276079','18 tống hữu định, thảo điền, quận 2, HCM','Nhà riêng',_binary '\0'),(2,7,'Xin Chào','1234567890','16 tống hữu định, thảo điền, quận 2, HCM','Công ty',_binary ''),(3,8,'','dsdsd','sdasda','Nhà riêng',_binary '');
/*!40000 ALTER TABLE `diachi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `donhang`
--

DROP TABLE IF EXISTS `donhang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `donhang` (
  `MaDonHang` int NOT NULL AUTO_INCREMENT,
  `MaTK` int DEFAULT NULL,
  `TongTien` decimal(10,2) DEFAULT NULL,
  `TrangThai` varchar(100) DEFAULT NULL,
  `PhuongThucThanhToan` varchar(500) DEFAULT NULL,
  `NgayDat` datetime DEFAULT CURRENT_TIMESTAMP,
  `DiaChiGiaoHang` varchar(500) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `SoDienThoai` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `GhiChu` varchar(1000) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `DaThanhToan` bit(1) DEFAULT b'0',
  `TenNguoiNhan` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`MaDonHang`),
  KEY `MaTK` (`MaTK`),
  CONSTRAINT `donhang_ibfk_1` FOREIGN KEY (`MaTK`) REFERENCES `taikhoan` (`MaTK`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `donhang`
--

LOCK TABLES `donhang` WRITE;
/*!40000 ALTER TABLE `donhang` DISABLE KEYS */;
INSERT INTO `donhang` VALUES (1,5,1430000.00,'Đang giao','Thanh toán khi nhận hàng (COD)','2026-04-04 02:05:51',NULL,NULL,NULL,_binary '\0',NULL),(2,5,1200000.00,'Đã giao thành công','Chuyển khoản ngân hàng (VNPAY)','2026-04-04 02:05:51',NULL,NULL,NULL,_binary '\0',NULL),(3,5,1430000.00,'Chờ xác nhận','Thanh toán khi nhận hàng (COD)','2026-04-04 02:06:09',NULL,NULL,NULL,_binary '\0',NULL),(4,5,1200000.00,'Đã giao thành công','Chuyển khoản ngân hàng (VNPAY)','2026-04-04 02:06:09',NULL,NULL,NULL,_binary '\0',NULL),(5,8,290000.00,'Mới','COD','2026-04-08 15:55:44','sdasda','dsdsd',NULL,_binary '\0',''),(6,7,350000.00,'Mới','COD','2026-04-08 19:16:55','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '\0','Xin Chào'),(7,7,350000.00,'Mới','COD','2026-04-08 19:20:39','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '\0','Xin Chào'),(8,7,350000.00,'Mới','COD','2026-04-08 19:25:34','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '\0','Xin Chào'),(9,7,350000.00,'Mới','COD','2026-04-08 19:27:54','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '\0','Xin Chào'),(10,7,350000.00,'Mới','VNPAY','2026-04-08 19:28:57','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '\0','Xin Chào'),(11,7,350000.00,'Mới','VNPAY','2026-04-08 19:38:53','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '\0','Xin Chào'),(12,7,350000.00,'Mới','VNPAY','2026-04-08 19:45:43','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '\0','Xin Chào'),(13,7,290000.00,'Mới','VNPAY','2026-04-08 19:47:44','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '\0','Xin Chào'),(14,8,350000.00,'Mới','VNPAY','2026-04-08 19:49:03','sdasda','dsdsd',NULL,_binary '\0',''),(15,8,350000.00,'Mới','VNPAY','2026-04-08 19:50:35','sdasda','dsdsd',NULL,_binary '\0',''),(16,8,350000.00,'Mới','VNPAY','2026-04-08 19:58:22','sdasda','dsdsd',NULL,_binary '\0',''),(17,8,290000.00,'Mới','VNPAY','2026-04-08 19:58:45','sdasda','dsdsd',NULL,_binary '\0',''),(18,7,290000.00,'Mới','VNPAY','2026-04-08 20:06:16','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '\0','Xin Chào'),(19,7,350000.00,'Mới','VNPAY','2026-04-08 20:47:14','18 tống hữu định, thảo điền, quận 2, HCM','0378276079',NULL,_binary '\0','Tri Nhânnn'),(20,7,350000.00,'Đã thanh toán','VNPAY','2026-04-08 20:48:48','16 tống hữu định, thảo điền, quận 2, HCM','1234567890',NULL,_binary '','Xin Chào'),(23,NULL,350000.00,'Mới','COD','2026-04-09 03:57:54','123fsfwe','123455',NULL,_binary '\0','eyroarh');
/*!40000 ALTER TABLE `donhang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `giohang`
--

DROP TABLE IF EXISTS `giohang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `giohang` (
  `MaGioHang` int NOT NULL AUTO_INCREMENT,
  `MaTK` int DEFAULT NULL,
  `NgayTao` datetime DEFAULT NULL,
  PRIMARY KEY (`MaGioHang`),
  KEY `MaTK` (`MaTK`),
  CONSTRAINT `giohang_ibfk_1` FOREIGN KEY (`MaTK`) REFERENCES `taikhoan` (`MaTK`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `giohang`
--

LOCK TABLES `giohang` WRITE;
/*!40000 ALTER TABLE `giohang` DISABLE KEYS */;
INSERT INTO `giohang` VALUES (2,5,'2026-04-04 02:03:00'),(3,5,'2026-04-04 02:03:16'),(4,5,'2026-04-04 02:04:39'),(5,5,'2026-04-04 02:05:11');
/*!40000 ALTER TABLE `giohang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kichco`
--

DROP TABLE IF EXISTS `kichco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kichco` (
  `MaKichCo` int NOT NULL AUTO_INCREMENT,
  `TenKichCo` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`MaKichCo`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kichco`
--

LOCK TABLES `kichco` WRITE;
/*!40000 ALTER TABLE `kichco` DISABLE KEYS */;
INSERT INTO `kichco` VALUES (1,'S'),(2,'M'),(3,'L'),(4,'XL'),(5,'XXL'),(6,'39'),(7,'40'),(8,'41'),(9,'42'),(10,'S'),(11,'M'),(12,'L'),(13,'XL'),(14,'XXL'),(15,'39'),(16,'40'),(17,'41'),(18,'42'),(19,'S'),(20,'M'),(21,'L'),(22,'XL'),(23,'XXL'),(24,'39'),(25,'40'),(26,'41'),(27,'42'),(28,'S'),(29,'M'),(30,'L'),(31,'XL'),(32,'XXL'),(33,'39'),(34,'40'),(35,'41'),(36,'42'),(37,'S'),(38,'M'),(39,'L'),(40,'XL'),(41,'XXL'),(42,'39'),(43,'40'),(44,'41'),(45,'42'),(46,'S'),(47,'M'),(48,'L'),(49,'XL'),(50,'XXL'),(51,'39'),(52,'40'),(53,'41'),(54,'42'),(55,'S'),(56,'M'),(57,'L'),(58,'XL'),(59,'XXL'),(60,'39'),(61,'40'),(62,'41'),(63,'42');
/*!40000 ALTER TABLE `kichco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loaisanpham`
--

DROP TABLE IF EXISTS `loaisanpham`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loaisanpham` (
  `MaLoai` int NOT NULL AUTO_INCREMENT,
  `TenLoai` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`MaLoai`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loaisanpham`
--

LOCK TABLES `loaisanpham` WRITE;
/*!40000 ALTER TABLE `loaisanpham` DISABLE KEYS */;
INSERT INTO `loaisanpham` VALUES (1,'Áo Khoác & Vest'),(2,'Áo Polo'),(3,'Áo Sơ Mi'),(4,'Quần (Jean, Tây, Short)'),(5,'Giày Da'),(6,'Tất (Socks)'),(7,'Thắt Lưng (Belts)');
/*!40000 ALTER TABLE `loaisanpham` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mausac`
--

DROP TABLE IF EXISTS `mausac`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mausac` (
  `MaMauSac` int NOT NULL AUTO_INCREMENT,
  `TenMauSac` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`MaMauSac`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mausac`
--

LOCK TABLES `mausac` WRITE;
/*!40000 ALTER TABLE `mausac` DISABLE KEYS */;
INSERT INTO `mausac` VALUES (1,'Đen'),(2,'Trắng'),(3,'Xanh Navy'),(4,'Xám'),(5,'Be'),(6,'Hồng'),(7,'Nâu'),(8,'Đen'),(9,'Trắng'),(10,'Xanh Navy'),(11,'Xám'),(12,'Be'),(13,'Hồng'),(14,'Nâu'),(15,'Đen'),(16,'Trắng'),(17,'Xanh Navy'),(18,'Xám'),(19,'Be'),(20,'Hồng'),(21,'Nâu'),(22,'Đen'),(23,'Trắng'),(24,'Xanh Navy'),(25,'Xám'),(26,'Be'),(27,'Hồng'),(28,'Nâu'),(29,'Đen'),(30,'Trắng'),(31,'Xanh Navy'),(32,'Xám'),(33,'Be'),(34,'Hồng'),(35,'Nâu'),(36,'Đen'),(37,'Trắng'),(38,'Xanh Navy'),(39,'Xám'),(40,'Be'),(41,'Hồng'),(42,'Nâu');
/*!40000 ALTER TABLE `mausac` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sanpham`
--

DROP TABLE IF EXISTS `sanpham`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sanpham` (
  `MaSP` int NOT NULL AUTO_INCREMENT,
  `TenSP` varchar(200) DEFAULT NULL,
  `Gia` decimal(10,2) DEFAULT NULL,
  `MoTa` text,
  `HinhAnh` varchar(500) DEFAULT NULL,
  `MaLoai` int DEFAULT NULL,
  PRIMARY KEY (`MaSP`),
  KEY `MaLoai` (`MaLoai`),
  CONSTRAINT `sanpham_ibfk_1` FOREIGN KEY (`MaLoai`) REFERENCES `loaisanpham` (`MaLoai`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sanpham`
--

LOCK TABLES `sanpham` WRITE;
/*!40000 ALTER TABLE `sanpham` DISABLE KEYS */;
INSERT INTO `sanpham` VALUES (1,'Áo Khoác Da Biker',750000.00,'Chất liệu da cao cấp, khóa kéo không gỉ','AoKhoac-daden.jpg',1),(2,'Áo Khoác Gió Đen Basic',420000.00,'Chống nắng và gió bụi hiệu quả','AoKhoac-gio-den.jpg',1),(3,'Áo Khoác Gió Đen 2026',420000.00,'Thiết kế form rộng trẻ trung','AoKhoac-gio-den1.jpg',1),(4,'Áo Khoác Gió Trắng',430000.00,'Màu trắng thanh lịch, vải dù mịn','AoKhoac-gio-trang.jpg',1),(5,'Áo Khoác Gió Trắng Sport',430000.00,'Phù hợp hoạt động thể thao','AoKhoac-gio-trang1.jpg',1),(6,'Áo Khoác Phao Dày',950000.00,'Lớp lót bông siêu ấm cho mùa đông','AoKhoac-phao.jpg',1),(7,'Bộ Vest Đen Luxury',2500000.00,'Vest nam may đo, form chuẩn','bovest-den.jpg',1),(8,'Bộ Vest Ghi Tối',2500000.00,'Màu xám ghi sang trọng lịch lãm','bovest-ghitoi.jpg',1),(9,'Bộ Vest Xanh Tím Than',2500000.00,'Màu Navy chuyên nghiệp cho quý ông','bovest-timthan.jpg',1),(10,'Áo Polo Be Cổ Bẻ',290000.00,'Vải cá sấu cotton thoáng mát','Ao-polo-be.jpg',2),(11,'Áo Polo Be Sport',290000.00,'Form dáng trẻ trung năng động','Ao-polp-be1.jpg',2),(12,'Áo Polo Đen Basic',290000.00,'Màu đen dễ phối đồ','Ao-polp-den.png',2),(13,'Áo Polo Đen Premium',290000.00,'Vải thun lạnh cao cấp','Ao-polp-den1.png',2),(14,'Áo Polo Xanh Tím Than 01',290000.00,'Màu sắc bền, không phai','Ao-polp-timthan.png',2),(15,'Áo Polo Xanh Tím Than 02',290000.00,'Thấm hút mồ hôi cực tốt','Ao-polp-timthan1.jpg',2),(16,'Áo Polo Trắng Tinh Khôi',290000.00,'Trắng basic cho mọi lứa tuổi','Ao-polp-trang.jpg',2),(17,'Áo Polo Trắng Cotton',290000.00,'Vải mềm mịn, không xù lông','Ao-polp-trang1.jpg',2),(18,'Sơ Mi Caro Đỏ Đen',350000.00,'Họa tiết caro kẻ ô lớn','ao-somi-taidai-caro.jpg',3),(19,'Sơ Mi Tay Ngắn Hồng',310000.00,'Màu hồng pastel nam tính','ao-somi-taingan-hong1.jpg',3),(20,'Sơ Mi Tay Ngắn Trắng',310000.00,'Vải Oxford chống nhăn','ao-somi-taingan-trang.jpg',3),(21,'Sơ Mi Tay Ngắn Trắng Lụa',310000.00,'Chất liệu lụa mềm mại','ao-somi-taingan-trang1.png',3),(22,'Sơ Mi Tay Ngắn Xanh Biển',310000.00,'Xanh dương mát mẻ ngày hè','ao-somi-taingan-xanh.jpg',3),(23,'Sơ Mi Tay Dài Caro Nhỏ',350000.00,'Họa tiết kẻ sọc nhỏ tinh tế','ao-somi-taydai-caro1.jpg',3),(24,'Sơ Mi Tay Dài Trắng Công Sở',350000.00,'Cổ đức cứng cáp','ao-somi-taydai-trang.jpg',3),(25,'Sơ Mi Tay Dài Trắng 02',350000.00,'Dáng Slimfit ôm vừa vặn','ao-somi-taydai-trang1.png',3),(26,'Sơ Mi Tay Dài Xanh Đậm',350000.00,'Lịch sự cho các buổi họp','ao-somi-taydai-xanh.jpg',3),(27,'Sơ Mi Tay Dài Xanh Oxford',350000.00,'Vải dày dặn, đứng form','ao-somi-taydai-xanh1.png',3),(28,'Sơ Mi Tay Ngắn Hồng Basic',310000.00,'Phù hợp đi chơi, dạo phố','ao-somi-tayngan-hong.jpg',3),(29,'Sơ Mi Tay Ngắn Xanh Nhạt',310000.00,'Xanh biển nhạt tươi sáng','ao-somi-tayngan-xanh1.png',3),(30,'Quần Jean Xanh Classic',480000.00,'Vải jean dày, bền màu','quan-jean.jpg',4),(31,'Quần Jean Đen Co Giãn',480000.00,'Chất jean đen cá tính','quan-jean-den.png',4),(32,'Quần Jean Tím Đen',480000.00,'Màu sắc độc đáo, thời thượng','quan-jean-timden.jpg',4),(33,'Quần Short Đen',220000.00,'Vải thun mặc thoải mái','quan-ngan-den.jpg',4),(34,'Quần Short Trắng',220000.00,'Kaki trắng sành điệu','quan-ngan-trang.png',4),(35,'Quần Short Xanh Nhạt',220000.00,'Phù hợp đi biển','quan-ngan-xanhnhat.jpg',4),(36,'Quần Tây Màu Be',450000.00,'Phong cách Hàn Quốc lịch sự','quan-tay-be.jpg',4),(37,'Quần Tây Đen Chuẩn',450000.00,'Ống đứng, vải không nhăn','quan-tay-den.jpg',4),(38,'Quần Tây Tím Đen',450000.00,'Phối đồ cực sang trọng','quan-tay-timden.jpg',4),(39,'Giày Da Oxford 01',1200000.00,'Giày buộc dây cổ điển','giayda1.jpg',5),(40,'Giày Da Loafer 02',1200000.00,'Giày lười tiện lợi, đẳng cấp','giayda2.jpg',5),(41,'Tất Cotton Trắng 01',30000.00,'Kháng khuẩn, khử mùi','tat1.png',6),(42,'Tất Cotton Xám 02',30000.00,'Mềm mại cho đôi chân','tat2.jpg',6),(43,'Tất Cotton Đen 03',30000.00,'Độ đàn hồi cao','tat3.jpg',6),(44,'Thắt Lưng Da Đen 01',350000.00,'Khóa tự động cao cấp','thatlung1.jpg',7),(45,'Thắt Lưng Da Nâu 02',350000.00,'Da bò sần phong cách','thatlung2.jpg',7),(46,'Thắt Lưng Khóa Kim 03',350000.00,'Đơn giản, tinh tế','thatlung3.jpg',7),(47,'Thắt Lưng Công Sở 04',350000.00,'Phù hợp quần tây','thatlung4.jpg',7),(48,'Thắt Lưng Thời Trang 05',350000.00,'Thiết kế hiện đại','thatlung5.jpg',7),(49,'Thắt Lưng Cao Cấp 06',350000.00,'Đi kèm hộp gỗ sang trọng','thatlung6.jpg',7);
/*!40000 ALTER TABLE `sanpham` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `taikhoan`
--

DROP TABLE IF EXISTS `taikhoan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `taikhoan` (
  `MaTK` int NOT NULL AUTO_INCREMENT,
  `Ten` varchar(200) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `MatKhau` varchar(200) DEFAULT NULL,
  `FullName` varchar(200) DEFAULT NULL,
  `Sdt` varchar(15) DEFAULT NULL,
  `DiaChi` varchar(500) DEFAULT NULL,
  `GioiTinh` varchar(100) DEFAULT NULL,
  `VaiTro` varchar(100) DEFAULT NULL,
  `ThoiGianTao` datetime DEFAULT CURRENT_TIMESTAMP,
  `Otp` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`MaTK`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `taikhoan`
--

LOCK TABLES `taikhoan` WRITE;
/*!40000 ALTER TABLE `taikhoan` DISABLE KEYS */;
INSERT INTO `taikhoan` VALUES (3,'chinhon','sugarchinhon00@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92','Tri Nhân','0378276079','18 tống hữu định, thảo điền, quận 2, HCM','Nam','Admin','2026-03-28 12:08:22',NULL),(5,'khachhang1','kh1@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92','Nguyễn Văn A','0912345678','TP.HCM','Nam','User','2026-04-04 02:01:07',NULL),(7,'chinhon123','duongtrinhan00@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92','Tri Nhân','0378276079','18 tống hữu định, thảo điền, quận 2, HCM','Nam','User','2026-04-04 03:37:25',NULL),(8,'siu1234','siu@gmail.com','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92','siuuu','12321313','12123123123','Nam','Admin','2026-04-08 15:54:01',NULL);
/*!40000 ALTER TABLE `taikhoan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `yeuthich`
--

DROP TABLE IF EXISTS `yeuthich`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `yeuthich` (
  `MaYeuThich` int NOT NULL AUTO_INCREMENT,
  `MaTK` int DEFAULT NULL,
  `MaSP` int DEFAULT NULL,
  `NgayThem` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`MaYeuThich`),
  KEY `MaTK` (`MaTK`),
  KEY `MaSP` (`MaSP`),
  CONSTRAINT `yeuthich_ibfk_1` FOREIGN KEY (`MaTK`) REFERENCES `taikhoan` (`MaTK`),
  CONSTRAINT `yeuthich_ibfk_2` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `yeuthich`
--

LOCK TABLES `yeuthich` WRITE;
/*!40000 ALTER TABLE `yeuthich` DISABLE KEYS */;
INSERT INTO `yeuthich` VALUES (3,7,26,'2026-04-08 02:49:01');
/*!40000 ALTER TABLE `yeuthich` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-09  5:16:08
