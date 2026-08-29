-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 29 Ağu 2026, 11:01:16
-- Sunucu sürümü: 10.4.32-MariaDB
-- PHP Sürümü: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `stoktakipdb`
--
CREATE DATABASE IF NOT EXISTS `stoktakipdb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `stoktakipdb`;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `cariler`
--

CREATE TABLE `cariler` (
  `CariID` int(11) NOT NULL,
  `AdSoyad` varchar(100) NOT NULL,
  `Telefon` varchar(15) DEFAULT NULL,
  `Adres` varchar(250) DEFAULT NULL,
  `Bakiye` decimal(18,2) DEFAULT 0.00,
  `IsActive` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `cariler`
--

INSERT INTO `cariler` (`CariID`, `AdSoyad`, `Telefon`, `Adres`, `Bakiye`, `IsActive`) VALUES
(1, 'Ahmet Yılmaz', '0532-111-2233', 'Kadıköy / İstanbul', 1500.00, 1),
(2, 'Mega Yazılım A.Ş.', '0212-333-4455', 'Şişli / İstanbul', -5000.00, 1),
(3, 'Ayşe Kaya', '0555-444-9988', 'Çankaya / Ankara', 0.00, 1),
(4, 'Tekno Market Ltd.', '0216-999-8877', 'Maltepe / İstanbul', 12500.50, 1),
(5, 'Mehmet Demir', '0544-777-6655', 'Bornova / İzmir', 350.00, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hareketler`
--

CREATE TABLE `hareketler` (
  `HareketID` int(11) NOT NULL,
  `CariID` int(11) DEFAULT NULL,
  `StokID` int(11) DEFAULT NULL,
  `IslemTipi` varchar(20) DEFAULT NULL,
  `Miktar` int(11) NOT NULL,
  `IslemTarihi` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `hareketler`
--

INSERT INTO `hareketler` (`HareketID`, `CariID`, `StokID`, `IslemTipi`, `Miktar`, `IslemTarihi`) VALUES
(1, 1, 1, 'Satış', 2, '2026-08-01 10:30:00'),
(2, 2, 3, 'Alış', 5, '2026-08-02 14:15:00'),
(3, 4, 2, 'Satış', 10, '2026-08-05 09:45:00'),
(4, 1, 4, 'Satış', 1, '2026-08-10 11:20:00'),
(5, 3, 1, 'Satış', 1, '2026-08-12 16:00:00'),
(6, 5, 5, 'Satış', 2, '2026-08-15 13:10:00'),
(7, 2, 3, 'Satış', 1, '2026-08-18 10:05:00'),
(8, 4, 4, 'Satış', 5, '2026-08-20 15:30:00'),
(9, 3, 2, 'Satış', 2, '2026-08-22 09:00:00'),
(10, 1, 5, 'Satış', 1, '2026-08-25 17:45:00');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanicilar`
--

CREATE TABLE `kullanicilar` (
  `KullaniciID` int(11) NOT NULL,
  `KullaniciAdi` varchar(50) NOT NULL,
  `SifreHash` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `kullanicilar`
--

INSERT INTO `kullanicilar` (`KullaniciID`, `KullaniciAdi`, `SifreHash`) VALUES
(1, 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'),
(2, 'furkan', '6d08ae12f856f44841006bb8970af5a1a036e7639ee42f7d3b3a1c4c03bac827'),
(3, 'admin', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92'),
(4, 'furkan', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `stoklar`
--

CREATE TABLE `stoklar` (
  `StokID` int(11) NOT NULL,
  `UrunKodu` varchar(50) NOT NULL,
  `UrunAdi` varchar(100) NOT NULL,
  `SatisFiyati` decimal(18,2) NOT NULL,
  `MevcutStok` int(11) DEFAULT 0,
  `IsActive` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `stoklar`
--

INSERT INTO `stoklar` (`StokID`, `UrunKodu`, `UrunAdi`, `SatisFiyati`, `MevcutStok`, `IsActive`) VALUES
(1, 'PRD-001', 'Muhasebe Pro Lisans', 2500.00, 50, 1),
(2, 'PRD-002', 'e-Dönüşüm Kontör (1000 Adet)', 450.00, 1000, 1),
(3, 'PRD-003', 'ERP Temel Modül', 15000.00, 10, 1),
(4, 'PRD-004', 'Barkod Okuyucu Cihaz', 850.50, 25, 1),
(5, 'PRD-005', 'Termal Fatura Yazıcı', 1200.00, 15, 1);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `cariler`
--
ALTER TABLE `cariler`
  ADD PRIMARY KEY (`CariID`);

--
-- Tablo için indeksler `hareketler`
--
ALTER TABLE `hareketler`
  ADD PRIMARY KEY (`HareketID`),
  ADD KEY `CariID` (`CariID`),
  ADD KEY `StokID` (`StokID`);

--
-- Tablo için indeksler `kullanicilar`
--
ALTER TABLE `kullanicilar`
  ADD PRIMARY KEY (`KullaniciID`);

--
-- Tablo için indeksler `stoklar`
--
ALTER TABLE `stoklar`
  ADD PRIMARY KEY (`StokID`),
  ADD UNIQUE KEY `UrunKodu` (`UrunKodu`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `cariler`
--
ALTER TABLE `cariler`
  MODIFY `CariID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `hareketler`
--
ALTER TABLE `hareketler`
  MODIFY `HareketID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Tablo için AUTO_INCREMENT değeri `kullanicilar`
--
ALTER TABLE `kullanicilar`
  MODIFY `KullaniciID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `stoklar`
--
ALTER TABLE `stoklar`
  MODIFY `StokID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `hareketler`
--
ALTER TABLE `hareketler`
  ADD CONSTRAINT `hareketler_ibfk_1` FOREIGN KEY (`CariID`) REFERENCES `cariler` (`CariID`),
  ADD CONSTRAINT `hareketler_ibfk_2` FOREIGN KEY (`StokID`) REFERENCES `stoklar` (`StokID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
