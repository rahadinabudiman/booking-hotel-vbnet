-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 07, 2023 at 05:37 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bookinghotel_kel3`
--

-- --------------------------------------------------------

--
-- Table structure for table `kamar`
--

CREATE TABLE `kamar` (
  `id_kamar` int(11) NOT NULL,
  `nomor_kamar` int(5) DEFAULT NULL,
  `tipe_kamar` varchar(10) DEFAULT NULL,
  `kapasitas` varchar(5) DEFAULT NULL,
  `status` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `kamar`
--

INSERT INTO `kamar` (`id_kamar`, `nomor_kamar`, `tipe_kamar`, `kapasitas`, `status`) VALUES
(2, 123, 'GEGE', '20', 0),
(3, 2001, 'DEBES', '1', 0),
(4, 101, 'GEGE', '1', 0),
(5, 1002, 'PERFECTOR', '3', 0),
(6, 2121, 'PERFECTOR', '10', 0);

-- --------------------------------------------------------

--
-- Table structure for table `kategori_kamar`
--

CREATE TABLE `kategori_kamar` (
  `id_kategori_kamar` int(11) NOT NULL,
  `tipe_kamar` varchar(10) DEFAULT NULL,
  `kapasitas` int(5) NOT NULL,
  `harga_kamar` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `kategori_kamar`
--

INSERT INTO `kategori_kamar` (`id_kategori_kamar`, `tipe_kamar`, `kapasitas`, `harga_kamar`) VALUES
(2, 'PERFECTOR', 10, 100),
(3, 'DEBES', 20, 2000),
(4, 'GEGE', 30, 50000);

-- --------------------------------------------------------

--
-- Table structure for table `layanan`
--

CREATE TABLE `layanan` (
  `id_layanan` int(11) NOT NULL,
  `nama_layanan` varchar(25) DEFAULT NULL,
  `kategori` varchar(10) DEFAULT NULL,
  `harga` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `layanan`
--

INSERT INTO `layanan` (`id_layanan`, `nama_layanan`, `kategori`, `harga`) VALUES
(1, 'Pisang Keju', 'Makanan', 5000),
(2, 'Martabak', 'Makanan', 15000),
(3, 'Bantal', 'Room', 15000),
(4, 'Selimut', 'Room', 30000),
(5, 'Es Jeruk', 'Minuman', 10000),
(6, 'Lemon Tea', 'Minuman', 15000);

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id_login` int(11) NOT NULL,
  `username` varchar(25) DEFAULT NULL,
  `password` varchar(25) DEFAULT NULL,
  `nama_admin` varchar(25) NOT NULL,
  `tipe_administrator` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id_login`, `username`, `password`, `nama_admin`, `tipe_administrator`) VALUES
(1, 'admin', 'admin', 'R4HA', 'Super Administrator'),
(2, 'r4ha', 'r4ha', 'Keyze', 'Super Administrator'),
(4, 'k', 'k', 'k', 'Super Administrator');

-- --------------------------------------------------------

--
-- Table structure for table `pesanan`
--

CREATE TABLE `pesanan` (
  `id_pesanan` int(11) NOT NULL,
  `id_pesan_kamar` int(11) DEFAULT NULL,
  `id_tamu` int(11) DEFAULT NULL,
  `id_layanan` int(11) DEFAULT NULL,
  `nama_layanan` varchar(25) DEFAULT NULL,
  `banyak_pesanan` int(5) DEFAULT NULL,
  `total_harga` int(20) DEFAULT NULL,
  `status_pesanan` int(2) DEFAULT NULL,
  `tanggal_pesan` date NOT NULL,
  `waktu_pesan` time NOT NULL,
  `tanggal_bayar` date NOT NULL,
  `waktu_bayar` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `pesan_kamar`
--

CREATE TABLE `pesan_kamar` (
  `id_pesan_kamar` int(11) NOT NULL,
  `invoice` varchar(25) DEFAULT NULL,
  `id_tamu` int(11) DEFAULT NULL,
  `jumlah_tamu` int(5) DEFAULT NULL,
  `id_kamar` int(11) NOT NULL,
  `tipe_kamar` varchar(10) NOT NULL,
  `harga_awal` int(10) NOT NULL,
  `tanggal_masuk` date DEFAULT NULL,
  `jam_masuk` time DEFAULT NULL,
  `lama_pesan` int(11) NOT NULL,
  `tanggal_keluar` date DEFAULT NULL,
  `jam_keluar` time DEFAULT NULL,
  `jumlah_deposit` int(11) DEFAULT NULL,
  `denda` int(10) NOT NULL,
  `harga_akhir` int(10) NOT NULL,
  `status_pesan` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `tamu`
--

CREATE TABLE `tamu` (
  `id_tamu` int(11) NOT NULL,
  `nama_depan_tamu` varchar(25) DEFAULT NULL,
  `nama_belakang_tamu` varchar(25) DEFAULT NULL,
  `panggilan_tamu` varchar(5) DEFAULT NULL,
  `identitas_tamu` varchar(10) DEFAULT NULL,
  `nomor_identitas` varchar(15) DEFAULT NULL,
  `warga_negara` varchar(5) DEFAULT NULL,
  `alamat_tinggal` varchar(50) DEFAULT NULL,
  `kota` varchar(50) DEFAULT NULL,
  `provinsi` varchar(50) DEFAULT NULL,
  `nomor_hp` varchar(15) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `status` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tamu`
--

INSERT INTO `tamu` (`id_tamu`, `nama_depan_tamu`, `nama_belakang_tamu`, `panggilan_tamu`, `identitas_tamu`, `nomor_identitas`, `warga_negara`, `alamat_tinggal`, `kota`, `provinsi`, `nomor_hp`, `email`, `status`) VALUES
(13, 'RAHADINA', 'BUDIMAN', 'Mr.', 'KTP', '2020', 'WNI', '1212', '1212', '1212', '8023', '0823', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kamar`
--
ALTER TABLE `kamar`
  ADD PRIMARY KEY (`id_kamar`);

--
-- Indexes for table `kategori_kamar`
--
ALTER TABLE `kategori_kamar`
  ADD PRIMARY KEY (`id_kategori_kamar`);

--
-- Indexes for table `layanan`
--
ALTER TABLE `layanan`
  ADD PRIMARY KEY (`id_layanan`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id_login`);

--
-- Indexes for table `pesanan`
--
ALTER TABLE `pesanan`
  ADD PRIMARY KEY (`id_pesanan`);

--
-- Indexes for table `pesan_kamar`
--
ALTER TABLE `pesan_kamar`
  ADD PRIMARY KEY (`id_pesan_kamar`);

--
-- Indexes for table `tamu`
--
ALTER TABLE `tamu`
  ADD PRIMARY KEY (`id_tamu`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `kamar`
--
ALTER TABLE `kamar`
  MODIFY `id_kamar` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `kategori_kamar`
--
ALTER TABLE `kategori_kamar`
  MODIFY `id_kategori_kamar` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `layanan`
--
ALTER TABLE `layanan`
  MODIFY `id_layanan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id_login` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `pesanan`
--
ALTER TABLE `pesanan`
  MODIFY `id_pesanan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `pesan_kamar`
--
ALTER TABLE `pesan_kamar`
  MODIFY `id_pesan_kamar` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `tamu`
--
ALTER TABLE `tamu`
  MODIFY `id_tamu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
