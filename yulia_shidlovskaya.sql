-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 02, 2019 at 09:16 AM
-- Server version: 5.7.24
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `yulia_shidlovskaya`
--
CREATE DATABASE IF NOT EXISTS `yulia_shidlovskaya` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `yulia_shidlovskaya`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `stylist_id` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phone_number` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `stylist_id`, `name`, `email`, `phone_number`) VALUES
(15, 58, 'Sunny', 'sunny@gmail.com', '(425)987-6543'),
(16, 59, 'Sunny', 'sunny@gmail.com', '(425)987-6543'),
(17, 60, 'Sunny', 'sunny@gmail.com', '(425)987-6543'),
(18, 61, 'Sunny', 'sunny@gmail.com', '(425)987-6543'),
(19, 62, 'Sun', 'sun@hotmail.com', '(123)456-7890'),
(20, 63, 'Sun', 'sun@hotmail.com', '(123)456-7890'),
(21, 74, 'Mike', 'mike@gmail.com', '(425)345-6789'),
(22, 75, 'Mike', 'mike@gmail.com', '(425)111-2222'),
(25, 78, 'Mike', 'mike@hotmail.com', '32343424'),
(26, 78, 'Tina', 'tina@hotmail.com', '23123213213'),
(27, 79, 'Dasha', 'dasha@hotmail.com', '23435680090332'),
(28, 79, 'Anya', 'dfsdfs@gmail.com', '2312321321'),
(29, 80, 'Miki', 'sjullieb@gmail.com', '422312321');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phone_number` varchar(15) NOT NULL,
  `schedule` varchar(255) DEFAULT NULL,
  `haircut_styles` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`, `email`, `phone_number`, `schedule`, `haircut_styles`) VALUES
(79, 'Yulia', 'mike@hotmail.com', 'Fri-Sat', '4252738747', 'any'),
(80, 'Amy', 'amy@gmail.com', 'Tue, Thur 10-3', '34567890', 'kids');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=81;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
