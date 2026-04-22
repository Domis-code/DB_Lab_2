CREATE DATABASE IF NOT EXISTS `lab_1` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `lab_1`;

INSERT INTO `Lytis` (`id`, `name`) VALUES
(1, 'Vyras'),
(2, 'Moteris')
ON DUPLICATE KEY UPDATE `name` = VALUES(`name`);

INSERT INTO `Kovos_Statusas` (`id`, `name`) VALUES
(1, 'Planuojama'),
(2, 'Ivykusi'),
(3, 'Atsaukta')
ON DUPLICATE KEY UPDATE `name` = VALUES(`name`);

INSERT INTO `Kovos_Pabaigos_Tipai` (`id`, `name`) VALUES
(1, 'Nokautas'),
(2, 'Techninis nokautas'),
(3, 'Pasidavimas'),
(4, 'Taskai'),
(99, 'Kova neivyko')
ON DUPLICATE KEY UPDATE `name` = VALUES(`name`);

INSERT INTO `Kovos_Taisykliu_tipai` (`id`, `name`) VALUES
(1, 'MMA'),
(2, 'Boksas'),
(3, 'Kikboksas'),
(4, 'Muay Thai')
ON DUPLICATE KEY UPDATE `name` = VALUES(`name`);

INSERT INTO `Laimejimo_Rezultatas` (`id`, `name`) VALUES
(1, 'Pergale'),
(2, 'Pralaimejimas'),
(3, 'Lygiosios'),
(99, 'Kova neivyko')
ON DUPLICATE KEY UPDATE `name` = VALUES(`name`);

INSERT INTO `Narystes_tipai` (`id`, `name`) VALUES
(1, 'Pilna naryste'),
(2, 'Laikina naryste'),
(3, 'Sutartine naryste')
ON DUPLICATE KEY UPDATE `name` = VALUES(`name`);

INSERT INTO `Statuso_tipai` (`id`, `name`) VALUES
(1, 'Aktyvus'),
(2, 'Sustabdyta'),
(3, 'Pasibaigusi')
ON DUPLICATE KEY UPDATE `name` = VALUES(`name`);

INSERT INTO `Tasku_sistema` (`id`, `name`) VALUES
(1, '10-point must'),
(2, 'Proprietary')
ON DUPLICATE KEY UPDATE `name` = VALUES(`name`);

INSERT INTO `Kovinio_Sporto_sales` (`Klubo_Pavadinimas`, `Miestas`, `Salis`, `Adresas`, `Telefono_nr`) VALUES
('Sparta Gym', 'Kaunas', 'Lietuva', 'Savanoriu pr. 100', '+37060000001'),
('Iron Wolf Club', 'Vilnius', 'Lietuva', 'Zalgirio g. 15', '+37060000002')
ON DUPLICATE KEY UPDATE
`Miestas` = VALUES(`Miestas`),
`Salis` = VALUES(`Salis`),
`Adresas` = VALUES(`Adresas`),
`Telefono_nr` = VALUES(`Telefono_nr`);

INSERT INTO `Kovotojai` (`id`, `Vardas`, `Pavarde`, `Gimimo_metai`, `Svoris_kg`, `Ugis_cm`) VALUES
(1, 'Mantas', 'Jankauskas', '1998-04-12', 77.50, 182),
(2, 'Lukas', 'Petrauskas', '1996-09-03', 78.20, 179),
(3, 'Tomas', 'Kazlauskas', '2000-01-21', 70.00, 175)
ON DUPLICATE KEY UPDATE
`Vardas` = VALUES(`Vardas`),
`Pavarde` = VALUES(`Pavarde`),
`Gimimo_metai` = VALUES(`Gimimo_metai`),
`Svoris_kg` = VALUES(`Svoris_kg`),
`Ugis_cm` = VALUES(`Ugis_cm`);

INSERT INTO `Renginys` (`Renginio_Pavadinimas`, `Renginio_Data`, `Vieta_adresas`, `Miestas`, `Organizatorius`) VALUES
('Baltic Fight Night', '2026-03-20', 'Arenos g. 1', 'Kaunas', 'BFL'),
('Vilnius Combat Open', '2026-04-11', 'Sporto g. 7', 'Vilnius', 'VCO')
ON DUPLICATE KEY UPDATE
`Renginio_Data` = VALUES(`Renginio_Data`),
`Vieta_adresas` = VALUES(`Vieta_adresas`),
`Miestas` = VALUES(`Miestas`),
`Organizatorius` = VALUES(`Organizatorius`);

INSERT INTO `Svorio_Kategorija` (`id`, `Sporto_Saka`, `Kategorijos_Pavadinimas`, `Min_kg`, `Max_kg`, `Amziaus_Grupe`, `Lyties_Grupe`) VALUES
(1, 'MMA', 'Lightweight', 70.00, 77.10, 1, 1),
(2, 'MMA', 'Welterweight', 77.10, 83.90, 1, 1)
ON DUPLICATE KEY UPDATE
`Sporto_Saka` = VALUES(`Sporto_Saka`),
`Kategorijos_Pavadinimas` = VALUES(`Kategorijos_Pavadinimas`),
`Min_kg` = VALUES(`Min_kg`),
`Max_kg` = VALUES(`Max_kg`),
`Amziaus_Grupe` = VALUES(`Amziaus_Grupe`),
`Lyties_Grupe` = VALUES(`Lyties_Grupe`);

INSERT INTO `Kovos_Taisykles` (`Taisykliu_pavadinimas`, `Raundu_Skaičius`, `Raundo_Trukme_min`, `Kovos_Taisykles`, `Taskų_sistema`) VALUES
('MMA Pro Rules', 3, 5, 1, 1),
('MMA Title Rules', 5, 5, 1, 1)
ON DUPLICATE KEY UPDATE
`Raundu_Skaičius` = VALUES(`Raundu_Skaičius`),
`Raundo_Trukme_min` = VALUES(`Raundo_Trukme_min`),
`Kovos_Taisykles` = VALUES(`Kovos_Taisykles`),
`Taskų_sistema` = VALUES(`Taskų_sistema`);

INSERT INTO `Treneriai` (`id`, `Vardas`, `Pavarde`, `Specializacija`, `Pareigos`, `Patirtis_metais`, `fk_Kovinio_Sporto_sales`) VALUES
(1, 'Darius', 'Maciulis', 'MMA Grappling', 'Vyr. treneris', 12, 'Sparta Gym'),
(2, 'Andrius', 'Valenta', 'Striking', 'Treneris', 8, 'Iron Wolf Club')
ON DUPLICATE KEY UPDATE
`Vardas` = VALUES(`Vardas`),
`Pavarde` = VALUES(`Pavarde`),
`Specializacija` = VALUES(`Specializacija`),
`Pareigos` = VALUES(`Pareigos`),
`Patirtis_metais` = VALUES(`Patirtis_metais`),
`fk_Kovinio_Sporto_sales` = VALUES(`fk_Kovinio_Sporto_sales`);

INSERT INTO `Kovos_duomenys` (`id`, `Kovos_Eile`, `Tituline_kova`, `Pastabos`, `Kovos_laikas_data`, `Kovos_statutas`, `fk_Svorio_Kategorija`, `fk_Renginys`, `fk_Kovos_Taisykles`) VALUES
(1, 1, 1, 'Vakaro pagrindine kova', '2026-03-20 20:00:00', 2, 2, 'Baltic Fight Night', 'MMA Title Rules'),
(2, 2, 0, 'Papildoma kova', '2026-03-20 19:20:00', 2, 1, 'Baltic Fight Night', 'MMA Pro Rules')
ON DUPLICATE KEY UPDATE
`Kovos_Eile` = VALUES(`Kovos_Eile`),
`Tituline_kova` = VALUES(`Tituline_kova`),
`Pastabos` = VALUES(`Pastabos`),
`Kovos_laikas_data` = VALUES(`Kovos_laikas_data`),
`Kovos_statutas` = VALUES(`Kovos_statutas`),
`fk_Svorio_Kategorija` = VALUES(`fk_Svorio_Kategorija`),
`fk_Renginys` = VALUES(`fk_Renginys`),
`fk_Kovos_Taisykles` = VALUES(`fk_Kovos_Taisykles`);

INSERT INTO `Kovotojo_Dalyvavimas` (`id`, `Baigties_raundas`, `Baigties_laikas_min`, `Baigties_laikas_sek`, `Baigties_Budas`, `Rezultatas`, `fk_Kovos_duomenys`, `fk_Kovotojai`) VALUES
(1, 3, 4, 12, 4, 1, 1, 1),
(2, 3, 4, 12, 4, 2, 1, 2),
(3, 2, 1, 44, 1, 1, 2, 2),
(4, 2, 1, 44, 1, 2, 2, 3)
ON DUPLICATE KEY UPDATE
`Baigties_raundas` = VALUES(`Baigties_raundas`),
`Baigties_laikas_min` = VALUES(`Baigties_laikas_min`),
`Baigties_laikas_sek` = VALUES(`Baigties_laikas_sek`),
`Baigties_Budas` = VALUES(`Baigties_Budas`),
`Rezultatas` = VALUES(`Rezultatas`),
`fk_Kovos_duomenys` = VALUES(`fk_Kovos_duomenys`),
`fk_Kovotojai` = VALUES(`fk_Kovotojai`);

INSERT INTO `Kovos_raundo_info` (`id`, `Raundo_Numeris`, `Raundo_Trukme_min`, `Raundo_Trukme_sek`, `Pastabos`, `Raundo_Pabaiga`, `fk_Kovos_duomenys`) VALUES
(1, 1, 5, 0, 'Atsargus pirmas raundas', 4, 1),
(2, 2, 5, 0, 'Didelis tempas', 4, 1),
(3, 3, 4, 12, 'Pergale taskais', 4, 1)
ON DUPLICATE KEY UPDATE
`Raundo_Numeris` = VALUES(`Raundo_Numeris`),
`Raundo_Trukme_min` = VALUES(`Raundo_Trukme_min`),
`Raundo_Trukme_sek` = VALUES(`Raundo_Trukme_sek`),
`Pastabos` = VALUES(`Pastabos`),
`Raundo_Pabaiga` = VALUES(`Raundo_Pabaiga`),
`fk_Kovos_duomenys` = VALUES(`fk_Kovos_duomenys`);

INSERT INTO `Kovotojo_sporto_saliu_istorija` (`id`, `Narystes_Pradzia`, `Narystes_Pabaiga`, `Pastabos`, `Narystes_tipas`, `Statusas`, `fk_Kovotojai`, `fk_Kovinio_Sporto_sales`) VALUES
(1, '2025-01-01', '2026-12-31', 'Pilnas sezonas', 1, 1, 1, 'Sparta Gym'),
(2, '2025-06-01', '2026-06-01', 'Kontrakto metai', 3, 1, 2, 'Iron Wolf Club')
ON DUPLICATE KEY UPDATE
`Narystes_Pradzia` = VALUES(`Narystes_Pradzia`),
`Narystes_Pabaiga` = VALUES(`Narystes_Pabaiga`),
`Pastabos` = VALUES(`Pastabos`),
`Narystes_tipas` = VALUES(`Narystes_tipas`),
`Statusas` = VALUES(`Statusas`),
`fk_Kovotojai` = VALUES(`fk_Kovotojai`),
`fk_Kovinio_Sporto_sales` = VALUES(`fk_Kovinio_Sporto_sales`);
