-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 22, 2026 at 06:46 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `lab_1`
--

-- --------------------------------------------------------

--
-- Table structure for table `kovinio_sporto_sales`
--

CREATE TABLE `kovinio_sporto_sales` (
  `Klubo_Pavadinimas` varchar(255) NOT NULL,
  `Miestas` varchar(100) NOT NULL,
  `Salis` varchar(100) NOT NULL,
  `Adresas` varchar(100) NOT NULL,
  `Telefono_nr` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovinio_sporto_sales`
--

INSERT INTO `kovinio_sporto_sales` (`Klubo_Pavadinimas`, `Miestas`, `Salis`, `Adresas`, `Telefono_nr`) VALUES
('Sporto sale 1', 'Miestas 1', 'Lietuva', 'Adresas 1', '+37060000001'),
('Sporto sale 10', 'Miestas 10', 'Lietuva', 'Adresas 10', '+37060000010'),
('Sporto sale 11', 'Miestas 11', 'Lietuva', 'Adresas 11', '+37060000011'),
('Sporto sale 12', 'Miestas 12', 'Lietuva', 'Adresas 12', '+37060000012'),
('Sporto sale 13', 'Miestas 13', 'Lietuva', 'Adresas 13', '+37060000013'),
('Sporto sale 14', 'Miestas 14', 'Lietuva', 'Adresas 14', '+37060000014'),
('Sporto sale 15', 'Miestas 15', 'Lietuva', 'Adresas 15', '+37060000015'),
('Sporto sale 16', 'Miestas 16', 'Lietuva', 'Adresas 16', '+37060000016'),
('Sporto sale 17', 'Miestas 17', 'Lietuva', 'Adresas 17', '+37060000017'),
('Sporto sale 18', 'Miestas 18', 'Lietuva', 'Adresas 18', '+37060000018'),
('Sporto sale 19', 'Miestas 19', 'Lietuva', 'Adresas 19', '+37060000019'),
('Sporto sale 2', 'Miestas 2', 'Lietuva', 'Adresas 2', '+37060000002'),
('Sporto sale 20', 'Miestas 20', 'Lietuva', 'Adresas 20', '+37060000020'),
('Sporto sale 21', 'Miestas 21', 'Lietuva', 'Adresas 21', '+37060000021'),
('Sporto sale 22', 'Miestas 22', 'Lietuva', 'Adresas 22', '+37060000022'),
('Sporto sale 23', 'Miestas 23', 'Lietuva', 'Adresas 23', '+37060000023'),
('Sporto sale 24', 'Miestas 24', 'Lietuva', 'Adresas 24', '+37060000024'),
('Sporto sale 25', 'Miestas 25', 'Lietuva', 'Adresas 25', '+37060000025'),
('Sporto sale 3', 'Miestas 3', 'Lietuva', 'Adresas 3', '+37060000003'),
('Sporto sale 4', 'Miestas 4', 'Lietuva', 'Adresas 4', '+37060000004'),
('Sporto sale 5', 'Miestas 5', 'Lietuva', 'Adresas 5', '+37060000005'),
('Sporto sale 6', 'Miestas 6', 'Lietuva', 'Adresas 6', '+37060000006'),
('Sporto sale 7', 'Miestas 7', 'Lietuva', 'Adresas 7', '+37060000007'),
('Sporto sale 8', 'Miestas 8', 'Lietuva', 'Adresas 8', '+37060000008'),
('Sporto sale 9', 'Miestas 9', 'Lietuva', 'Adresas 9', '+37060000009');

-- --------------------------------------------------------

--
-- Table structure for table `kovos_duomenys`
--

CREATE TABLE `kovos_duomenys` (
  `id` int(11) NOT NULL,
  `Kovos_Eile` int(2) NOT NULL,
  `Tituline_kova` tinyint(1) NOT NULL,
  `Pastabos` varchar(100) DEFAULT NULL,
  `Kovos_laikas_data` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Kovos_statutas` int(11) NOT NULL,
  `fk_Svorio_Kategorija` int(11) NOT NULL,
  `fk_Renginys` varchar(255) NOT NULL,
  `fk_Kovos_Taisykles` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovos_duomenys`
--

INSERT INTO `kovos_duomenys` (`id`, `Kovos_Eile`, `Tituline_kova`, `Pastabos`, `Kovos_laikas_data`, `Kovos_statutas`, `fk_Svorio_Kategorija`, `fk_Renginys`, `fk_Kovos_Taisykles`) VALUES
(1, 1, 0, 'Kovos pastaba 1', '2026-02-01 17:00:00', 1, 1, 'Renginys 1', 'Taisykles 1'),
(2, 2, 0, 'Kovos pastaba 2', '2026-02-01 18:00:00', 2, 2, 'Renginys 2', 'Taisykles 2'),
(3, 3, 0, 'Kovos pastaba 3', '2026-02-01 19:00:00', 3, 3, 'Renginys 3', 'Taisykles 3'),
(4, 4, 0, 'Kovos pastaba 4', '2026-02-01 20:00:00', 1, 4, 'Renginys 4', 'Taisykles 4'),
(5, 5, 1, 'Kovos pastaba 5', '2026-02-01 21:00:00', 2, 5, 'Renginys 5', 'Taisykles 5'),
(6, 6, 0, 'Kovos pastaba 6', '2026-02-01 22:00:00', 3, 6, 'Renginys 6', 'Taisykles 6'),
(7, 7, 0, 'Kovos pastaba 7', '2026-02-01 23:00:00', 1, 7, 'Renginys 7', 'Taisykles 7'),
(8, 8, 0, 'Kovos pastaba 8', '2026-02-02 00:00:00', 2, 8, 'Renginys 8', 'Taisykles 8'),
(9, 9, 0, 'Kovos pastaba 9', '2026-02-02 01:00:00', 3, 9, 'Renginys 9', 'Taisykles 9'),
(10, 10, 1, 'Kovos pastaba 10', '2026-02-02 02:00:00', 1, 10, 'Renginys 10', 'Taisykles 10'),
(11, 11, 0, 'Kovos pastaba 11', '2026-02-02 03:00:00', 2, 11, 'Renginys 11', 'Taisykles 11'),
(12, 12, 0, 'Kovos pastaba 12', '2026-02-02 04:00:00', 3, 12, 'Renginys 12', 'Taisykles 12'),
(13, 13, 0, 'Kovos pastaba 13', '2026-02-02 05:00:00', 1, 13, 'Renginys 13', 'Taisykles 13'),
(14, 14, 0, 'Kovos pastaba 14', '2026-02-02 06:00:00', 2, 14, 'Renginys 14', 'Taisykles 14'),
(15, 15, 1, 'Kovos pastaba 15', '2026-02-02 07:00:00', 3, 15, 'Renginys 15', 'Taisykles 15'),
(16, 16, 0, 'Kovos pastaba 16', '2026-02-02 08:00:00', 1, 16, 'Renginys 16', 'Taisykles 16'),
(17, 17, 0, 'Kovos pastaba 17', '2026-02-02 09:00:00', 2, 17, 'Renginys 17', 'Taisykles 17'),
(18, 18, 0, 'Kovos pastaba 18', '2026-02-02 10:00:00', 3, 18, 'Renginys 18', 'Taisykles 18'),
(19, 19, 0, 'Kovos pastaba 19', '2026-02-02 11:00:00', 1, 19, 'Renginys 19', 'Taisykles 19'),
(20, 20, 1, 'Kovos pastaba 20', '2026-02-02 12:00:00', 2, 20, 'Renginys 20', 'Taisykles 20'),
(21, 21, 0, 'Kovos pastaba 21', '2026-02-02 13:00:00', 3, 21, 'Renginys 21', 'Taisykles 21'),
(22, 22, 0, 'Kovos pastaba 22', '2026-02-02 14:00:00', 1, 22, 'Renginys 22', 'Taisykles 22'),
(23, 23, 0, 'Kovos pastaba 23', '2026-02-02 15:00:00', 2, 23, 'Renginys 23', 'Taisykles 23'),
(24, 24, 0, 'Kovos pastaba 24', '2026-02-02 16:00:00', 3, 24, 'Renginys 24', 'Taisykles 24'),
(25, 25, 1, 'Kovos pastaba 25', '2026-02-02 17:00:00', 1, 25, 'Renginys 25', 'Taisykles 25');

-- --------------------------------------------------------

--
-- Table structure for table `kovos_pabaigos_tipai`
--

CREATE TABLE `kovos_pabaigos_tipai` (
  `id` int(11) NOT NULL,
  `name` char(17) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovos_pabaigos_tipai`
--

INSERT INTO `kovos_pabaigos_tipai` (`id`, `name`) VALUES
(1, 'Nokautas'),
(2, 'Techninis nokauta'),
(3, 'Pasidavimas'),
(4, 'Taskai'),
(5, 'Kova neivyko'),
(6, 'Baigtis 6'),
(7, 'Baigtis 7'),
(8, 'Baigtis 8'),
(9, 'Baigtis 9'),
(10, 'Baigtis 10'),
(11, 'Baigtis 11'),
(12, 'Baigtis 12'),
(13, 'Baigtis 13'),
(14, 'Baigtis 14'),
(15, 'Baigtis 15'),
(16, 'Baigtis 16'),
(17, 'Baigtis 17'),
(18, 'Baigtis 18'),
(19, 'Baigtis 19'),
(20, 'Baigtis 20'),
(21, 'Baigtis 21'),
(22, 'Baigtis 22'),
(23, 'Baigtis 23'),
(24, 'Baigtis 24'),
(25, 'Baigtis 25');

-- --------------------------------------------------------

--
-- Table structure for table `kovos_raundo_info`
--

CREATE TABLE `kovos_raundo_info` (
  `id` int(11) NOT NULL,
  `Raundo_Numeris` int(2) NOT NULL,
  `Raundo_Trukme_min` int(2) DEFAULT NULL,
  `Raundo_Trukme_sek` int(2) NOT NULL,
  `Pastabos` varchar(100) DEFAULT NULL,
  `Raundo_Pabaiga` int(11) NOT NULL,
  `fk_Kovos_duomenys` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovos_raundo_info`
--

INSERT INTO `kovos_raundo_info` (`id`, `Raundo_Numeris`, `Raundo_Trukme_min`, `Raundo_Trukme_sek`, `Pastabos`, `Raundo_Pabaiga`, `fk_Kovos_duomenys`) VALUES
(1, 3, 5, 0, 'Raundo pastaba 1', 1, 1),
(2, 3, 5, 0, 'Raundo pastaba 2', 2, 2),
(3, 3, 5, 0, 'Raundo pastaba 3', 3, 3),
(4, 3, 5, 0, 'Raundo pastaba 4', 4, 4),
(5, 5, 5, 0, 'Raundo pastaba 5', 5, 5),
(6, 3, 5, 0, 'Raundo pastaba 6', 1, 6),
(7, 3, 5, 0, 'Raundo pastaba 7', 2, 7),
(8, 3, 5, 0, 'Raundo pastaba 8', 3, 8),
(9, 3, 5, 0, 'Raundo pastaba 9', 4, 9),
(10, 5, 5, 0, 'Raundo pastaba 10', 5, 10),
(11, 3, 5, 0, 'Raundo pastaba 11', 1, 11),
(12, 3, 5, 0, 'Raundo pastaba 12', 2, 12),
(13, 3, 5, 0, 'Raundo pastaba 13', 3, 13),
(14, 3, 5, 0, 'Raundo pastaba 14', 4, 14),
(15, 5, 5, 0, 'Raundo pastaba 15', 5, 15),
(16, 3, 5, 0, 'Raundo pastaba 16', 1, 16),
(17, 3, 5, 0, 'Raundo pastaba 17', 2, 17),
(18, 3, 5, 0, 'Raundo pastaba 18', 3, 18),
(19, 3, 5, 0, 'Raundo pastaba 19', 4, 19),
(20, 5, 5, 0, 'Raundo pastaba 20', 5, 20),
(21, 3, 5, 0, 'Raundo pastaba 21', 1, 21),
(22, 3, 5, 0, 'Raundo pastaba 22', 2, 22),
(23, 3, 5, 0, 'Raundo pastaba 23', 3, 23),
(24, 3, 5, 0, 'Raundo pastaba 24', 4, 24),
(25, 5, 5, 0, 'Raundo pastaba 25', 5, 25);

-- --------------------------------------------------------

--
-- Table structure for table `kovos_statusas`
--

CREATE TABLE `kovos_statusas` (
  `id` int(11) NOT NULL,
  `name` char(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovos_statusas`
--

INSERT INTO `kovos_statusas` (`id`, `name`) VALUES
(1, 'Planuojama'),
(2, 'Ivykusi'),
(3, 'Atsaukta'),
(4, 'Statusas 4'),
(5, 'Statusas 5'),
(6, 'Statusas 6'),
(7, 'Statusas 7'),
(8, 'Statusas 8'),
(9, 'Statusas 9'),
(10, 'Statusas 1'),
(11, 'Statusas 1'),
(12, 'Statusas 1'),
(13, 'Statusas 1'),
(14, 'Statusas 1'),
(15, 'Statusas 1'),
(16, 'Statusas 1'),
(17, 'Statusas 1'),
(18, 'Statusas 1'),
(19, 'Statusas 1'),
(20, 'Statusas 2'),
(21, 'Statusas 2'),
(22, 'Statusas 2'),
(23, 'Statusas 2'),
(24, 'Statusas 2'),
(25, 'Statusas 2');

-- --------------------------------------------------------

--
-- Table structure for table `kovos_taisykles`
--

CREATE TABLE `kovos_taisykles` (
  `Taisykliu_pavadinimas` varchar(100) NOT NULL,
  `Raundu_Skaičius` int(2) NOT NULL,
  `Raundo_Trukme_min` int(2) NOT NULL,
  `Kovos_Taisykles` int(11) NOT NULL,
  `Taskų_sistema` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovos_taisykles`
--

INSERT INTO `kovos_taisykles` (`Taisykliu_pavadinimas`, `Raundu_Skaičius`, `Raundo_Trukme_min`, `Kovos_Taisykles`, `Taskų_sistema`) VALUES
('Taisykles 1', 3, 5, 1, 1),
('Taisykles 10', 5, 5, 10, 10),
('Taisykles 11', 3, 5, 11, 11),
('Taisykles 12', 5, 5, 12, 12),
('Taisykles 13', 3, 5, 13, 13),
('Taisykles 14', 5, 5, 14, 14),
('Taisykles 15', 3, 5, 15, 15),
('Taisykles 16', 5, 5, 16, 16),
('Taisykles 17', 3, 5, 17, 17),
('Taisykles 18', 5, 5, 18, 18),
('Taisykles 19', 3, 5, 19, 19),
('Taisykles 2', 5, 5, 2, 2),
('Taisykles 20', 5, 5, 20, 20),
('Taisykles 21', 3, 5, 21, 21),
('Taisykles 22', 5, 5, 22, 22),
('Taisykles 23', 3, 5, 23, 23),
('Taisykles 24', 5, 5, 24, 24),
('Taisykles 25', 3, 5, 25, 25),
('Taisykles 3', 3, 5, 3, 3),
('Taisykles 4', 5, 5, 4, 4),
('Taisykles 5', 3, 5, 5, 5),
('Taisykles 6', 5, 5, 6, 6),
('Taisykles 7', 3, 5, 7, 7),
('Taisykles 8', 5, 5, 8, 8),
('Taisykles 9', 3, 5, 9, 9);

-- --------------------------------------------------------

--
-- Table structure for table `kovos_taisykliu_tipai`
--

CREATE TABLE `kovos_taisykliu_tipai` (
  `id` int(11) NOT NULL,
  `name` char(19) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovos_taisykliu_tipai`
--

INSERT INTO `kovos_taisykliu_tipai` (`id`, `name`) VALUES
(1, 'MMA'),
(2, 'Boksas'),
(3, 'Kikboksas'),
(4, 'Muay Thai'),
(5, 'Taisykliu tipas 5'),
(6, 'Taisykliu tipas 6'),
(7, 'Taisykliu tipas 7'),
(8, 'Taisykliu tipas 8'),
(9, 'Taisykliu tipas 9'),
(10, 'Taisykliu tipas 10'),
(11, 'Taisykliu tipas 11'),
(12, 'Taisykliu tipas 12'),
(13, 'Taisykliu tipas 13'),
(14, 'Taisykliu tipas 14'),
(15, 'Taisykliu tipas 15'),
(16, 'Taisykliu tipas 16'),
(17, 'Taisykliu tipas 17'),
(18, 'Taisykliu tipas 18'),
(19, 'Taisykliu tipas 19'),
(20, 'Taisykliu tipas 20'),
(21, 'Taisykliu tipas 21'),
(22, 'Taisykliu tipas 22'),
(23, 'Taisykliu tipas 23'),
(24, 'Taisykliu tipas 24'),
(25, 'Taisykliu tipas 25');

-- --------------------------------------------------------

--
-- Table structure for table `kovotojai`
--

CREATE TABLE `kovotojai` (
  `id` int(11) NOT NULL,
  `Vardas` varchar(100) NOT NULL,
  `Pavarde` varchar(100) NOT NULL,
  `Gimimo_metai` date NOT NULL,
  `Svoris_kg` float(5,2) NOT NULL,
  `Ugis_cm` int(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovotojai`
--

INSERT INTO `kovotojai` (`id`, `Vardas`, `Pavarde`, `Gimimo_metai`, `Svoris_kg`, `Ugis_cm`) VALUES
(1, 'Kovotojas1', 'Pavarde1', '1990-06-30', 61.00, 166),
(2, 'Kovotojas2', 'Pavarde2', '1990-12-27', 62.00, 167),
(3, 'Kovotojas3', 'Pavarde3', '1991-06-25', 63.00, 168),
(4, 'Kovotojas4', 'Pavarde4', '1991-12-22', 64.00, 169),
(5, 'Kovotojas5', 'Pavarde5', '1992-06-19', 65.00, 170),
(6, 'Kovotojas6', 'Pavarde6', '1992-12-16', 66.00, 171),
(7, 'Kovotojas7', 'Pavarde7', '1993-06-14', 67.00, 172),
(8, 'Kovotojas8', 'Pavarde8', '1993-12-11', 68.00, 173),
(9, 'Kovotojas9', 'Pavarde9', '1994-06-09', 69.00, 174),
(10, 'Kovotojas10', 'Pavarde10', '1994-12-06', 70.00, 175),
(11, 'Kovotojas11', 'Pavarde11', '1995-06-04', 71.00, 176),
(12, 'Kovotojas12', 'Pavarde12', '1995-12-01', 72.00, 177),
(13, 'Kovotojas13', 'Pavarde13', '1996-05-29', 73.00, 178),
(14, 'Kovotojas14', 'Pavarde14', '1996-11-25', 74.00, 179),
(15, 'Kovotojas15', 'Pavarde15', '1997-05-24', 75.00, 180),
(16, 'Kovotojas16', 'Pavarde16', '1997-11-20', 76.00, 181),
(17, 'Kovotojas17', 'Pavarde17', '1998-05-19', 77.00, 182),
(18, 'Kovotojas18', 'Pavarde18', '1998-11-15', 78.00, 183),
(19, 'Kovotojas19', 'Pavarde19', '1999-05-14', 79.00, 184),
(20, 'Kovotojas20', 'Pavarde20', '1999-11-10', 80.00, 165),
(21, 'Kovotojas21', 'Pavarde21', '2000-05-08', 81.00, 166),
(22, 'Kovotojas22', 'Pavarde22', '2000-11-04', 82.00, 167),
(23, 'Kovotojas23', 'Pavarde23', '2001-05-03', 83.00, 168),
(24, 'Kovotojas24', 'Pavarde24', '2001-10-30', 84.00, 169),
(25, 'Kovotojas25', 'Pavarde25', '2002-04-28', 85.00, 170);

-- --------------------------------------------------------

--
-- Table structure for table `kovotojo_dalyvavimas`
--

CREATE TABLE `kovotojo_dalyvavimas` (
  `id` int(11) NOT NULL,
  `Baigties_raundas` int(2) NOT NULL,
  `Baigties_laikas_min` int(2) NOT NULL,
  `Baigties_laikas_sek` int(2) NOT NULL,
  `Baigties_Budas` int(11) NOT NULL,
  `Rezultatas` int(11) NOT NULL,
  `fk_Kovos_duomenys` int(11) NOT NULL,
  `fk_Kovotojai` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovotojo_dalyvavimas`
--

INSERT INTO `kovotojo_dalyvavimas` (`id`, `Baigties_raundas`, `Baigties_laikas_min`, `Baigties_laikas_sek`, `Baigties_Budas`, `Rezultatas`, `fk_Kovos_duomenys`, `fk_Kovotojai`) VALUES
(1, 3, 4, 20, 4, 1, 1, 1),
(2, 3, 4, 20, 4, 1, 2, 2),
(3, 3, 4, 20, 4, 1, 3, 3),
(4, 3, 4, 20, 4, 1, 4, 4),
(5, 3, 4, 20, 4, 1, 5, 5),
(6, 3, 4, 20, 4, 1, 6, 6),
(7, 3, 4, 20, 4, 1, 7, 7),
(8, 3, 4, 20, 4, 1, 8, 8),
(9, 3, 4, 20, 4, 1, 9, 9),
(10, 3, 4, 20, 4, 1, 10, 10),
(11, 3, 4, 20, 4, 1, 11, 11),
(12, 3, 4, 20, 4, 1, 12, 12),
(13, 3, 4, 20, 4, 1, 13, 13),
(14, 3, 4, 20, 4, 1, 14, 14),
(15, 3, 4, 20, 4, 1, 15, 15),
(16, 3, 4, 20, 4, 1, 16, 16),
(17, 3, 4, 20, 4, 1, 17, 17),
(18, 3, 4, 20, 4, 1, 18, 18),
(19, 3, 4, 20, 4, 1, 19, 19),
(20, 3, 4, 20, 4, 1, 20, 20),
(21, 3, 4, 20, 4, 1, 21, 21),
(22, 3, 4, 20, 4, 1, 22, 22),
(23, 3, 4, 20, 4, 1, 23, 23),
(24, 3, 4, 20, 4, 1, 24, 24),
(25, 3, 4, 20, 4, 1, 25, 25),
(26, 3, 4, 20, 4, 2, 1, 2),
(27, 3, 4, 20, 4, 2, 2, 3),
(28, 3, 4, 20, 4, 2, 3, 4),
(29, 3, 4, 20, 4, 2, 4, 5),
(30, 3, 4, 20, 4, 2, 5, 6),
(31, 3, 4, 20, 4, 2, 6, 7),
(32, 3, 4, 20, 4, 2, 7, 8),
(33, 3, 4, 20, 4, 2, 8, 9),
(34, 3, 4, 20, 4, 2, 9, 10),
(35, 3, 4, 20, 4, 2, 10, 11),
(36, 3, 4, 20, 4, 2, 11, 12),
(37, 3, 4, 20, 4, 2, 12, 13),
(38, 3, 4, 20, 4, 2, 13, 14),
(39, 3, 4, 20, 4, 2, 14, 15),
(40, 3, 4, 20, 4, 2, 15, 16),
(41, 3, 4, 20, 4, 2, 16, 17),
(42, 3, 4, 20, 4, 2, 17, 18),
(43, 3, 4, 20, 4, 2, 18, 19),
(44, 3, 4, 20, 4, 2, 19, 20),
(45, 3, 4, 20, 4, 2, 20, 21),
(46, 3, 4, 20, 4, 2, 21, 22),
(47, 3, 4, 20, 4, 2, 22, 23),
(48, 3, 4, 20, 4, 2, 23, 24),
(49, 3, 4, 20, 4, 2, 24, 25),
(50, 3, 4, 20, 4, 2, 25, 1);

-- --------------------------------------------------------

--
-- Table structure for table `kovotojo_sporto_saliu_istorija`
--

CREATE TABLE `kovotojo_sporto_saliu_istorija` (
  `id` int(11) NOT NULL,
  `Narystes_Pradzia` date NOT NULL,
  `Narystes_Pabaiga` date NOT NULL,
  `Pastabos` varchar(100) DEFAULT NULL,
  `Narystes_tipas` int(11) NOT NULL,
  `Statusas` int(11) DEFAULT NULL,
  `fk_Kovotojai` int(11) NOT NULL,
  `fk_Kovinio_Sporto_sales` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `kovotojo_sporto_saliu_istorija`
--

INSERT INTO `kovotojo_sporto_saliu_istorija` (`id`, `Narystes_Pradzia`, `Narystes_Pabaiga`, `Pastabos`, `Narystes_tipas`, `Statusas`, `fk_Kovotojai`, `fk_Kovinio_Sporto_sales`) VALUES
(1, '2025-01-02', '2026-01-02', 'Istorijos pastaba 1', 1, 1, 1, 'Sporto sale 1'),
(2, '2025-01-03', '2026-01-03', 'Istorijos pastaba 2', 2, 2, 2, 'Sporto sale 2'),
(3, '2025-01-04', '2026-01-04', 'Istorijos pastaba 3', 3, 3, 3, 'Sporto sale 3'),
(4, '2025-01-05', '2026-01-05', 'Istorijos pastaba 4', 1, 1, 4, 'Sporto sale 4'),
(5, '2025-01-06', '2026-01-06', 'Istorijos pastaba 5', 2, 2, 5, 'Sporto sale 5'),
(6, '2025-01-07', '2026-01-07', 'Istorijos pastaba 6', 3, 3, 6, 'Sporto sale 6'),
(7, '2025-01-08', '2026-01-08', 'Istorijos pastaba 7', 1, 1, 7, 'Sporto sale 7'),
(8, '2025-01-09', '2026-01-09', 'Istorijos pastaba 8', 2, 2, 8, 'Sporto sale 8'),
(9, '2025-01-10', '2026-01-10', 'Istorijos pastaba 9', 3, 3, 9, 'Sporto sale 9'),
(10, '2025-01-11', '2026-01-11', 'Istorijos pastaba 10', 1, 1, 10, 'Sporto sale 10'),
(11, '2025-01-12', '2026-01-12', 'Istorijos pastaba 11', 2, 2, 11, 'Sporto sale 11'),
(12, '2025-01-13', '2026-01-13', 'Istorijos pastaba 12', 3, 3, 12, 'Sporto sale 12'),
(13, '2025-01-14', '2026-01-14', 'Istorijos pastaba 13', 1, 1, 13, 'Sporto sale 13'),
(14, '2025-01-15', '2026-01-15', 'Istorijos pastaba 14', 2, 2, 14, 'Sporto sale 14'),
(15, '2025-01-16', '2026-01-16', 'Istorijos pastaba 15', 3, 3, 15, 'Sporto sale 15'),
(16, '2025-01-17', '2026-01-17', 'Istorijos pastaba 16', 1, 1, 16, 'Sporto sale 16'),
(17, '2025-01-18', '2026-01-18', 'Istorijos pastaba 17', 2, 2, 17, 'Sporto sale 17'),
(18, '2025-01-19', '2026-01-19', 'Istorijos pastaba 18', 3, 3, 18, 'Sporto sale 18'),
(19, '2025-01-20', '2026-01-20', 'Istorijos pastaba 19', 1, 1, 19, 'Sporto sale 19'),
(20, '2025-01-21', '2026-01-21', 'Istorijos pastaba 20', 2, 2, 20, 'Sporto sale 20'),
(21, '2025-01-22', '2026-01-22', 'Istorijos pastaba 21', 3, 3, 21, 'Sporto sale 21'),
(22, '2025-01-23', '2026-01-23', 'Istorijos pastaba 22', 1, 1, 22, 'Sporto sale 22'),
(23, '2025-01-24', '2026-01-24', 'Istorijos pastaba 23', 2, 2, 23, 'Sporto sale 23'),
(24, '2025-01-25', '2026-01-25', 'Istorijos pastaba 24', 3, 3, 24, 'Sporto sale 24'),
(25, '2025-01-26', '2026-01-26', 'Istorijos pastaba 25', 1, 1, 25, 'Sporto sale 25');

-- --------------------------------------------------------

--
-- Table structure for table `laimejimo_rezultatas`
--

CREATE TABLE `laimejimo_rezultatas` (
  `id` int(11) NOT NULL,
  `name` char(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `laimejimo_rezultatas`
--

INSERT INTO `laimejimo_rezultatas` (`id`, `name`) VALUES
(1, 'Pergale'),
(2, 'Pralaimeji'),
(3, 'Lygiosios'),
(4, 'Kova neivy'),
(5, 'Rezultatas'),
(6, 'Rezultatas'),
(7, 'Rezultatas'),
(8, 'Rezultatas'),
(9, 'Rezultatas'),
(10, 'Rezultatas'),
(11, 'Rezultatas'),
(12, 'Rezultatas'),
(13, 'Rezultatas'),
(14, 'Rezultatas'),
(15, 'Rezultatas'),
(16, 'Rezultatas'),
(17, 'Rezultatas'),
(18, 'Rezultatas'),
(19, 'Rezultatas'),
(20, 'Rezultatas'),
(21, 'Rezultatas'),
(22, 'Rezultatas'),
(23, 'Rezultatas'),
(24, 'Rezultatas'),
(25, 'Rezultatas');

-- --------------------------------------------------------

--
-- Table structure for table `lytis`
--

CREATE TABLE `lytis` (
  `id` int(11) NOT NULL,
  `name` char(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `lytis`
--

INSERT INTO `lytis` (`id`, `name`) VALUES
(1, 'Vyras'),
(2, 'Moteris'),
(3, 'Lytis 3'),
(4, 'Lytis 4'),
(5, 'Lytis 5'),
(6, 'Lytis 6'),
(7, 'Lytis 7'),
(8, 'Lytis 8'),
(9, 'Lytis 9'),
(10, 'Lytis 1'),
(11, 'Lytis 1'),
(12, 'Lytis 1'),
(13, 'Lytis 1'),
(14, 'Lytis 1'),
(15, 'Lytis 1'),
(16, 'Lytis 1'),
(17, 'Lytis 1'),
(18, 'Lytis 1'),
(19, 'Lytis 1'),
(20, 'Lytis 2'),
(21, 'Lytis 2'),
(22, 'Lytis 2'),
(23, 'Lytis 2'),
(24, 'Lytis 2'),
(25, 'Lytis 2');

-- --------------------------------------------------------

--
-- Table structure for table `narystes_tipai`
--

CREATE TABLE `narystes_tipai` (
  `id` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `narystes_tipai`
--

INSERT INTO `narystes_tipai` (`id`, `name`) VALUES
(1, 'Pilna narys'),
(2, 'Laikina nar'),
(3, 'Sutartine n'),
(4, 'Narystes ti'),
(5, 'Narystes ti'),
(6, 'Narystes ti'),
(7, 'Narystes ti'),
(8, 'Narystes ti'),
(9, 'Narystes ti'),
(10, 'Narystes ti'),
(11, 'Narystes ti'),
(12, 'Narystes ti'),
(13, 'Narystes ti'),
(14, 'Narystes ti'),
(15, 'Narystes ti'),
(16, 'Narystes ti'),
(17, 'Narystes ti'),
(18, 'Narystes ti'),
(19, 'Narystes ti'),
(20, 'Narystes ti'),
(21, 'Narystes ti'),
(22, 'Narystes ti'),
(23, 'Narystes ti'),
(24, 'Narystes ti'),
(25, 'Narystes ti');

-- --------------------------------------------------------

--
-- Table structure for table `renginys`
--

CREATE TABLE `renginys` (
  `Renginio_Pavadinimas` varchar(255) NOT NULL,
  `Renginio_Data` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Vieta_adresas` varchar(255) NOT NULL,
  `Miestas` varchar(255) NOT NULL,
  `Organizatorius` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `renginys`
--

INSERT INTO `renginys` (`Renginio_Pavadinimas`, `Renginio_Data`, `Vieta_adresas`, `Miestas`, `Organizatorius`) VALUES
('Renginys 1', '2026-01-01 22:00:00', 'Arena 1', 'Miestas 1', 'Organizatorius 1'),
('Renginys 10', '2026-01-10 22:00:00', 'Arena 10', 'Miestas 10', 'Organizatorius 10'),
('Renginys 11', '2026-01-11 22:00:00', 'Arena 11', 'Miestas 11', 'Organizatorius 11'),
('Renginys 12', '2026-01-12 22:00:00', 'Arena 12', 'Miestas 12', 'Organizatorius 12'),
('Renginys 13', '2026-01-13 22:00:00', 'Arena 13', 'Miestas 13', 'Organizatorius 13'),
('Renginys 14', '2026-01-14 22:00:00', 'Arena 14', 'Miestas 14', 'Organizatorius 14'),
('Renginys 15', '2026-01-15 22:00:00', 'Arena 15', 'Miestas 15', 'Organizatorius 15'),
('Renginys 16', '2026-01-16 22:00:00', 'Arena 16', 'Miestas 16', 'Organizatorius 16'),
('Renginys 17', '2026-01-17 22:00:00', 'Arena 17', 'Miestas 17', 'Organizatorius 17'),
('Renginys 18', '2026-01-18 22:00:00', 'Arena 18', 'Miestas 18', 'Organizatorius 18'),
('Renginys 19', '2026-01-19 22:00:00', 'Arena 19', 'Miestas 19', 'Organizatorius 19'),
('Renginys 2', '2026-01-02 22:00:00', 'Arena 2', 'Miestas 2', 'Organizatorius 2'),
('Renginys 20', '2026-01-20 22:00:00', 'Arena 20', 'Miestas 20', 'Organizatorius 20'),
('Renginys 21', '2026-01-21 22:00:00', 'Arena 21', 'Miestas 21', 'Organizatorius 21'),
('Renginys 22', '2026-01-22 22:00:00', 'Arena 22', 'Miestas 22', 'Organizatorius 22'),
('Renginys 23', '2026-01-23 22:00:00', 'Arena 23', 'Miestas 23', 'Organizatorius 23'),
('Renginys 24', '2026-01-24 22:00:00', 'Arena 24', 'Miestas 24', 'Organizatorius 24'),
('Renginys 25', '2026-01-25 22:00:00', 'Arena 25', 'Miestas 25', 'Organizatorius 25'),
('Renginys 3', '2026-01-03 22:00:00', 'Arena 3', 'Miestas 3', 'Organizatorius 3'),
('Renginys 4', '2026-01-04 22:00:00', 'Arena 4', 'Miestas 4', 'Organizatorius 4'),
('Renginys 5', '2026-01-05 22:00:00', 'Arena 5', 'Miestas 5', 'Organizatorius 5'),
('Renginys 6', '2026-01-06 22:00:00', 'Arena 6', 'Miestas 6', 'Organizatorius 6'),
('Renginys 7', '2026-01-07 22:00:00', 'Arena 7', 'Miestas 7', 'Organizatorius 7'),
('Renginys 8', '2026-01-08 22:00:00', 'Arena 8', 'Miestas 8', 'Organizatorius 8'),
('Renginys 9', '2026-01-09 22:00:00', 'Arena 9', 'Miestas 9', 'Organizatorius 9');

-- --------------------------------------------------------

--
-- Table structure for table `statuso_tipai`
--

CREATE TABLE `statuso_tipai` (
  `id` int(11) NOT NULL,
  `name` char(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `statuso_tipai`
--

INSERT INTO `statuso_tipai` (`id`, `name`) VALUES
(1, 'Aktyvus'),
(2, 'Sustabdyta'),
(3, 'Pasibaigus'),
(4, 'Statusas 4'),
(5, 'Statusas 5'),
(6, 'Statusas 6'),
(7, 'Statusas 7'),
(8, 'Statusas 8'),
(9, 'Statusas 9'),
(10, 'Statusas 1'),
(11, 'Statusas 1'),
(12, 'Statusas 1'),
(13, 'Statusas 1'),
(14, 'Statusas 1'),
(15, 'Statusas 1'),
(16, 'Statusas 1'),
(17, 'Statusas 1'),
(18, 'Statusas 1'),
(19, 'Statusas 1'),
(20, 'Statusas 2'),
(21, 'Statusas 2'),
(22, 'Statusas 2'),
(23, 'Statusas 2'),
(24, 'Statusas 2'),
(25, 'Statusas 2');

-- --------------------------------------------------------

--
-- Table structure for table `svorio_kategorija`
--

CREATE TABLE `svorio_kategorija` (
  `id` int(11) NOT NULL,
  `Sporto_Saka` varchar(100) NOT NULL,
  `Kategorijos_Pavadinimas` varchar(30) NOT NULL,
  `Min_kg` float(5,2) NOT NULL,
  `Max_kg` float(5,2) NOT NULL,
  `Amziaus_Grupe` int(3) NOT NULL,
  `Lyties_Grupe` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `svorio_kategorija`
--

INSERT INTO `svorio_kategorija` (`id`, `Sporto_Saka`, `Kategorijos_Pavadinimas`, `Min_kg`, `Max_kg`, `Amziaus_Grupe`, `Lyties_Grupe`) VALUES
(1, 'MMA', 'Kategorija 1', 51.00, 52.00, 1, 1),
(2, 'MMA', 'Kategorija 2', 52.00, 53.00, 1, 2),
(3, 'MMA', 'Kategorija 3', 53.00, 54.00, 1, 1),
(4, 'MMA', 'Kategorija 4', 54.00, 55.00, 1, 2),
(5, 'MMA', 'Kategorija 5', 55.00, 56.00, 1, 1),
(6, 'MMA', 'Kategorija 6', 56.00, 57.00, 1, 2),
(7, 'MMA', 'Kategorija 7', 57.00, 58.00, 1, 1),
(8, 'MMA', 'Kategorija 8', 58.00, 59.00, 1, 2),
(9, 'MMA', 'Kategorija 9', 59.00, 60.00, 1, 1),
(10, 'MMA', 'Kategorija 10', 60.00, 61.00, 1, 2),
(11, 'MMA', 'Kategorija 11', 61.00, 62.00, 1, 1),
(12, 'MMA', 'Kategorija 12', 62.00, 63.00, 1, 2),
(13, 'MMA', 'Kategorija 13', 63.00, 64.00, 1, 1),
(14, 'MMA', 'Kategorija 14', 64.00, 65.00, 1, 2),
(15, 'MMA', 'Kategorija 15', 65.00, 66.00, 1, 1),
(16, 'MMA', 'Kategorija 16', 66.00, 67.00, 1, 2),
(17, 'MMA', 'Kategorija 17', 67.00, 68.00, 1, 1),
(18, 'MMA', 'Kategorija 18', 68.00, 69.00, 1, 2),
(19, 'MMA', 'Kategorija 19', 69.00, 70.00, 1, 1),
(20, 'MMA', 'Kategorija 20', 70.00, 71.00, 1, 2),
(21, 'MMA', 'Kategorija 21', 71.00, 72.00, 1, 1),
(22, 'MMA', 'Kategorija 22', 72.00, 73.00, 1, 2),
(23, 'MMA', 'Kategorija 23', 73.00, 74.00, 1, 1),
(24, 'MMA', 'Kategorija 24', 74.00, 75.00, 1, 2),
(25, 'MMA', 'Kategorija 25', 75.00, 76.00, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tasku_sistema`
--

CREATE TABLE `tasku_sistema` (
  `id` int(11) NOT NULL,
  `name` char(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `tasku_sistema`
--

INSERT INTO `tasku_sistema` (`id`, `name`) VALUES
(1, '10-point must'),
(2, 'Tasku sistema'),
(3, 'Tasku sistema'),
(4, 'Tasku sistema'),
(5, 'Tasku sistema'),
(6, 'Tasku sistema'),
(7, 'Tasku sistema'),
(8, 'Tasku sistema'),
(9, 'Tasku sistema'),
(10, 'Tasku sistema'),
(11, 'Tasku sistema'),
(12, 'Tasku sistema'),
(13, 'Tasku sistema'),
(14, 'Tasku sistema'),
(15, 'Tasku sistema'),
(16, 'Tasku sistema'),
(17, 'Tasku sistema'),
(18, 'Tasku sistema'),
(19, 'Tasku sistema'),
(20, 'Tasku sistema'),
(21, 'Tasku sistema'),
(22, 'Tasku sistema'),
(23, 'Tasku sistema'),
(24, 'Tasku sistema'),
(25, 'Tasku sistema');

-- --------------------------------------------------------

--
-- Table structure for table `treneriai`
--

CREATE TABLE `treneriai` (
  `id` int(11) NOT NULL,
  `Vardas` varchar(100) NOT NULL,
  `Pavarde` varchar(100) NOT NULL,
  `Specializacija` varchar(100) NOT NULL,
  `Pareigos` varchar(100) NOT NULL,
  `Patirtis_metais` int(2) NOT NULL,
  `fk_Kovinio_Sporto_sales` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `treneriai`
--

INSERT INTO `treneriai` (`id`, `Vardas`, `Pavarde`, `Specializacija`, `Pareigos`, `Patirtis_metais`, `fk_Kovinio_Sporto_sales`) VALUES
(1, 'Treneris1', 'Pavarde1', 'Specializacija 1', 'Treneris', 4, 'Sporto sale 1'),
(2, 'Treneris2', 'Pavarde2', 'Specializacija 2', 'Treneris', 5, 'Sporto sale 2'),
(3, 'Treneris3', 'Pavarde3', 'Specializacija 3', 'Treneris', 6, 'Sporto sale 3'),
(4, 'Treneris4', 'Pavarde4', 'Specializacija 4', 'Treneris', 7, 'Sporto sale 4'),
(5, 'Treneris5', 'Pavarde5', 'Specializacija 5', 'Treneris', 8, 'Sporto sale 5'),
(6, 'Treneris6', 'Pavarde6', 'Specializacija 6', 'Treneris', 9, 'Sporto sale 6'),
(7, 'Treneris7', 'Pavarde7', 'Specializacija 7', 'Treneris', 10, 'Sporto sale 7'),
(8, 'Treneris8', 'Pavarde8', 'Specializacija 8', 'Treneris', 11, 'Sporto sale 8'),
(9, 'Treneris9', 'Pavarde9', 'Specializacija 9', 'Treneris', 12, 'Sporto sale 9'),
(10, 'Treneris10', 'Pavarde10', 'Specializacija 10', 'Treneris', 13, 'Sporto sale 10'),
(11, 'Treneris11', 'Pavarde11', 'Specializacija 11', 'Treneris', 14, 'Sporto sale 11'),
(12, 'Treneris12', 'Pavarde12', 'Specializacija 12', 'Treneris', 15, 'Sporto sale 12'),
(13, 'Treneris13', 'Pavarde13', 'Specializacija 13', 'Treneris', 16, 'Sporto sale 13'),
(14, 'Treneris14', 'Pavarde14', 'Specializacija 14', 'Treneris', 17, 'Sporto sale 14'),
(15, 'Treneris15', 'Pavarde15', 'Specializacija 15', 'Treneris', 3, 'Sporto sale 15'),
(16, 'Treneris16', 'Pavarde16', 'Specializacija 16', 'Treneris', 4, 'Sporto sale 16'),
(17, 'Treneris17', 'Pavarde17', 'Specializacija 17', 'Treneris', 5, 'Sporto sale 17'),
(18, 'Treneris18', 'Pavarde18', 'Specializacija 18', 'Treneris', 6, 'Sporto sale 18'),
(19, 'Treneris19', 'Pavarde19', 'Specializacija 19', 'Treneris', 7, 'Sporto sale 19'),
(20, 'Treneris20', 'Pavarde20', 'Specializacija 20', 'Treneris', 8, 'Sporto sale 20'),
(21, 'Treneris21', 'Pavarde21', 'Specializacija 21', 'Treneris', 9, 'Sporto sale 21'),
(22, 'Treneris22', 'Pavarde22', 'Specializacija 22', 'Treneris', 10, 'Sporto sale 22'),
(23, 'Treneris23', 'Pavarde23', 'Specializacija 23', 'Treneris', 11, 'Sporto sale 23'),
(24, 'Treneris24', 'Pavarde24', 'Specializacija 24', 'Treneris', 12, 'Sporto sale 24'),
(25, 'Treneris25', 'Pavarde25', 'Specializacija 25', 'Treneris', 13, 'Sporto sale 25');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kovinio_sporto_sales`
--
ALTER TABLE `kovinio_sporto_sales`
  ADD PRIMARY KEY (`Klubo_Pavadinimas`);

--
-- Indexes for table `kovos_duomenys`
--
ALTER TABLE `kovos_duomenys`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Kovos_statutas` (`Kovos_statutas`),
  ADD KEY `fk_Svorio_Kategorija` (`fk_Svorio_Kategorija`),
  ADD KEY `fk_Renginys` (`fk_Renginys`),
  ADD KEY `fk_Kovos_Taisykles` (`fk_Kovos_Taisykles`);

--
-- Indexes for table `kovos_pabaigos_tipai`
--
ALTER TABLE `kovos_pabaigos_tipai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kovos_raundo_info`
--
ALTER TABLE `kovos_raundo_info`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Raundo_Pabaiga` (`Raundo_Pabaiga`),
  ADD KEY `fk_Kovos_duomenys` (`fk_Kovos_duomenys`);

--
-- Indexes for table `kovos_statusas`
--
ALTER TABLE `kovos_statusas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kovos_taisykles`
--
ALTER TABLE `kovos_taisykles`
  ADD PRIMARY KEY (`Taisykliu_pavadinimas`),
  ADD KEY `Kovos_Taisykles` (`Kovos_Taisykles`),
  ADD KEY `Taskų_sistema` (`Taskų_sistema`);

--
-- Indexes for table `kovos_taisykliu_tipai`
--
ALTER TABLE `kovos_taisykliu_tipai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kovotojai`
--
ALTER TABLE `kovotojai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kovotojo_dalyvavimas`
--
ALTER TABLE `kovotojo_dalyvavimas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Baigties_Budas` (`Baigties_Budas`),
  ADD KEY `Rezultatas` (`Rezultatas`),
  ADD KEY `fk_Kovos_duomenys` (`fk_Kovos_duomenys`),
  ADD KEY `fk_Kovotojai` (`fk_Kovotojai`);

--
-- Indexes for table `kovotojo_sporto_saliu_istorija`
--
ALTER TABLE `kovotojo_sporto_saliu_istorija`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Narystes_tipas` (`Narystes_tipas`),
  ADD KEY `Statusas` (`Statusas`),
  ADD KEY `fk_Kovotojai` (`fk_Kovotojai`),
  ADD KEY `fk_Kovinio_Sporto_sales` (`fk_Kovinio_Sporto_sales`);

--
-- Indexes for table `laimejimo_rezultatas`
--
ALTER TABLE `laimejimo_rezultatas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `lytis`
--
ALTER TABLE `lytis`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `narystes_tipai`
--
ALTER TABLE `narystes_tipai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `renginys`
--
ALTER TABLE `renginys`
  ADD PRIMARY KEY (`Renginio_Pavadinimas`);

--
-- Indexes for table `statuso_tipai`
--
ALTER TABLE `statuso_tipai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `svorio_kategorija`
--
ALTER TABLE `svorio_kategorija`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Lyties_Grupe` (`Lyties_Grupe`);

--
-- Indexes for table `tasku_sistema`
--
ALTER TABLE `tasku_sistema`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `treneriai`
--
ALTER TABLE `treneriai`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Kovinio_Sporto_sales` (`fk_Kovinio_Sporto_sales`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `kovos_duomenys`
--
ALTER TABLE `kovos_duomenys`
  ADD CONSTRAINT `kovos_duomenys_ibfk_1` FOREIGN KEY (`Kovos_statutas`) REFERENCES `kovos_statusas` (`id`),
  ADD CONSTRAINT `kovos_duomenys_ibfk_2` FOREIGN KEY (`fk_Svorio_Kategorija`) REFERENCES `svorio_kategorija` (`id`),
  ADD CONSTRAINT `kovos_duomenys_ibfk_3` FOREIGN KEY (`fk_Renginys`) REFERENCES `renginys` (`Renginio_Pavadinimas`),
  ADD CONSTRAINT `kovos_duomenys_ibfk_4` FOREIGN KEY (`fk_Kovos_Taisykles`) REFERENCES `kovos_taisykles` (`Taisykliu_pavadinimas`);

--
-- Constraints for table `kovos_raundo_info`
--
ALTER TABLE `kovos_raundo_info`
  ADD CONSTRAINT `kovos_raundo_info_ibfk_1` FOREIGN KEY (`Raundo_Pabaiga`) REFERENCES `kovos_pabaigos_tipai` (`id`),
  ADD CONSTRAINT `kovos_raundo_info_ibfk_2` FOREIGN KEY (`fk_Kovos_duomenys`) REFERENCES `kovos_duomenys` (`id`);

--
-- Constraints for table `kovos_taisykles`
--
ALTER TABLE `kovos_taisykles`
  ADD CONSTRAINT `kovos_taisykles_ibfk_1` FOREIGN KEY (`Kovos_Taisykles`) REFERENCES `kovos_taisykliu_tipai` (`id`),
  ADD CONSTRAINT `kovos_taisykles_ibfk_2` FOREIGN KEY (`Taskų_sistema`) REFERENCES `tasku_sistema` (`id`);

--
-- Constraints for table `kovotojo_dalyvavimas`
--
ALTER TABLE `kovotojo_dalyvavimas`
  ADD CONSTRAINT `kovotojo_dalyvavimas_ibfk_1` FOREIGN KEY (`Baigties_Budas`) REFERENCES `kovos_pabaigos_tipai` (`id`),
  ADD CONSTRAINT `kovotojo_dalyvavimas_ibfk_2` FOREIGN KEY (`Rezultatas`) REFERENCES `laimejimo_rezultatas` (`id`),
  ADD CONSTRAINT `kovotojo_dalyvavimas_ibfk_3` FOREIGN KEY (`fk_Kovos_duomenys`) REFERENCES `kovos_duomenys` (`id`),
  ADD CONSTRAINT `kovotojo_dalyvavimas_ibfk_4` FOREIGN KEY (`fk_Kovotojai`) REFERENCES `kovotojai` (`id`);

--
-- Constraints for table `kovotojo_sporto_saliu_istorija`
--
ALTER TABLE `kovotojo_sporto_saliu_istorija`
  ADD CONSTRAINT `kovotojo_sporto_saliu_istorija_ibfk_1` FOREIGN KEY (`Narystes_tipas`) REFERENCES `narystes_tipai` (`id`),
  ADD CONSTRAINT `kovotojo_sporto_saliu_istorija_ibfk_2` FOREIGN KEY (`Statusas`) REFERENCES `statuso_tipai` (`id`),
  ADD CONSTRAINT `kovotojo_sporto_saliu_istorija_ibfk_3` FOREIGN KEY (`fk_Kovotojai`) REFERENCES `kovotojai` (`id`),
  ADD CONSTRAINT `kovotojo_sporto_saliu_istorija_ibfk_4` FOREIGN KEY (`fk_Kovinio_Sporto_sales`) REFERENCES `kovinio_sporto_sales` (`Klubo_Pavadinimas`);

--
-- Constraints for table `svorio_kategorija`
--
ALTER TABLE `svorio_kategorija`
  ADD CONSTRAINT `svorio_kategorija_ibfk_1` FOREIGN KEY (`Lyties_Grupe`) REFERENCES `lytis` (`id`);

--
-- Constraints for table `treneriai`
--
ALTER TABLE `treneriai`
  ADD CONSTRAINT `treneriai_ibfk_1` FOREIGN KEY (`fk_Kovinio_Sporto_sales`) REFERENCES `kovinio_sporto_sales` (`Klubo_Pavadinimas`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
