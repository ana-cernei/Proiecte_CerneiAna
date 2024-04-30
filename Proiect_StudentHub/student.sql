-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gazdă: 127.0.0.1
-- Timp de generare: feb. 07, 2024 la 03:20 PM
-- Versiune server: 10.4.32-MariaDB
-- Versiune PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Bază de date: `student`
--

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `mail` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `admin`
--

INSERT INTO `admin` (`id`, `mail`, `password`) VALUES
(3, 'ana@gmail.com', '1234'),
(21, 'tudor@gmail.com', '123'),
(24, 'ana ', '1'),
(25, 'tudor@gmail.com', '1'),
(26, 'ana', '1'),
(27, 'ana', '1'),
(28, 'ana', '1'),
(29, 'ana', '1'),
(30, 'tudor ', '1'),
(31, 'ana', '1');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `class`
--

CREATE TABLE `class` (
  `id` int(11) NOT NULL,
  `major` varchar(200) NOT NULL,
  `spots` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `class`
--

INSERT INTO `class` (`id`, `major`, `spots`) VALUES
(18, 'Informatica Romana', '20'),
(19, 'Informatica Engleza', '25'),
(20, 'Informatica aplicata', '40'),
(21, 'Matematica Romana', '20'),
(22, 'Matematica Engleza', '30'),
(23, 'Matematica Informatica Romana', '40'),
(26, 'Matematica Informatica Engleza', '35');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `grades`
--

CREATE TABLE `grades` (
  `id` int(11) NOT NULL,
  `student_id` int(11) DEFAULT NULL,
  `subject` varchar(50) DEFAULT NULL,
  `average` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `grades`
--

INSERT INTO `grades` (`id`, `student_id`, `subject`, `average`) VALUES
(1, 1, 'p2', 10),
(2, 2, 'sda', 9),
(6, 3, 'lc', 8.5),
(7, 10, 'p3', 9);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `students`
--

CREATE TABLE `students` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `Age` int(10) NOT NULL,
  `Gender` varchar(10) NOT NULL,
  `Address` varchar(50) NOT NULL,
  `College` varchar(40) NOT NULL,
  `Phone` int(15) NOT NULL,
  `Major` varchar(100) NOT NULL,
  `Section` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `students`
--

INSERT INTO `students` (`id`, `name`, `Age`, `Gender`, `Address`, `College`, `Phone`, `Major`, `Section`) VALUES
(1, 'Ana', 21, 'Female', 'Strasa Barbu Iscovescu Timisoara', 'CND', 789345690, 'Informatica Romana', 1),
(2, 'Tudor', 20, 'Male', 'Strada Unirii Timisoara', 'CND', 789657832, 'Informatica Romana', 7),
(3, 'Andreea Vonica', 22, 'Female', 'Strada Take Ionescu Timisoara', 'CRM', 789651123, 'Matematica Engleza', 1),
(4, 'Pop Ana', 21, 'Female', 'Bd ul Republicii Timisoara', 'CNB', 798667543, 'Matematica Romana', 8),
(10, 'Cernei Tudor', 21, 'Male', 'Calea Sagului Timisoara', 'CRM', 789654432, 'Matematica Informatica Romana', 2),
(14, 'Laslau Bianca', 21, 'Female', 'Strada Barbu Iscovescu 7', 'CND', 789657789, 'Informatica Engleza', 6),
(15, 'Ana', 21, 'Female', 'strad', 'cnd', 876, 'Informatica Romana', 1);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `student_archive`
--

CREATE TABLE `student_archive` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `college` varchar(255) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `major` varchar(255) DEFAULT NULL,
  `section` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `student_archive`
--

INSERT INTO `student_archive` (`id`, `name`, `age`, `gender`, `address`, `college`, `phone`, `major`, `section`) VALUES
(1, 'Matei', 23, 'Male', 'Strada Delfinului Timisoara', 'CRM', '789654345', 'Matematica Informatica Romana', '5');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `subject`
--

CREATE TABLE `subject` (
  `subj_id` int(11) NOT NULL,
  `subject` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Eliminarea datelor din tabel `subject`
--

INSERT INTO `subject` (`subj_id`, `subject`) VALUES
(1, 'asd'),
(2, 'p2'),
(3, 'lc'),
(4, 'sda'),
(5, 'tgc'),
(6, 'p1'),
(7, 'p3'),
(8, 'ac'),
(12, 'bd'),
(13, 'so'),
(14, 'sda');

--
-- Indexuri pentru tabele eliminate
--

--
-- Indexuri pentru tabele `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexuri pentru tabele `class`
--
ALTER TABLE `class`
  ADD PRIMARY KEY (`id`);

--
-- Indexuri pentru tabele `grades`
--
ALTER TABLE `grades`
  ADD PRIMARY KEY (`id`),
  ADD KEY `student_id` (`student_id`);

--
-- Indexuri pentru tabele `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- Indexuri pentru tabele `student_archive`
--
ALTER TABLE `student_archive`
  ADD PRIMARY KEY (`id`);

--
-- Indexuri pentru tabele `subject`
--
ALTER TABLE `subject`
  ADD PRIMARY KEY (`subj_id`);

--
-- AUTO_INCREMENT pentru tabele eliminate
--

--
-- AUTO_INCREMENT pentru tabele `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT pentru tabele `class`
--
ALTER TABLE `class`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT pentru tabele `grades`
--
ALTER TABLE `grades`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT pentru tabele `students`
--
ALTER TABLE `students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT pentru tabele `student_archive`
--
ALTER TABLE `student_archive`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pentru tabele `subject`
--
ALTER TABLE `subject`
  MODIFY `subj_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Constrângeri pentru tabele eliminate
--

--
-- Constrângeri pentru tabele `grades`
--
ALTER TABLE `grades`
  ADD CONSTRAINT `grades_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
