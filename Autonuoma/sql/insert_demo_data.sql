SET FOREIGN_KEY_CHECKS=0;

DELETE FROM `Kovotojo_Dalyvavimas`;
DELETE FROM `Kovos_raundo_info`;
DELETE FROM `Kovotojo_sporto_saliu_istorija`;
DELETE FROM `Kovos_duomenys`;
DELETE FROM `Treneriai`;
DELETE FROM `Kovotojai`;
DELETE FROM `Svorio_Kategorija`;
DELETE FROM `Renginys`;
DELETE FROM `Kovos_Taisykles`;
DELETE FROM `Kovinio_Sporto_sales`;
DELETE FROM `Lytis`;
DELETE FROM `Kovos_Statusas`;
DELETE FROM `Kovos_Pabaigos_Tipai`;
DELETE FROM `Kovos_Taisykliu_tipai`;
DELETE FROM `Laimejimo_Rezultatas`;
DELETE FROM `Narystes_tipai`;
DELETE FROM `Statuso_tipai`;
DELETE FROM `Tasku_sistema`;

ALTER TABLE `Kovotojo_Dalyvavimas` AUTO_INCREMENT = 1;
ALTER TABLE `Kovos_raundo_info` AUTO_INCREMENT = 1;
ALTER TABLE `Kovotojo_sporto_saliu_istorija` AUTO_INCREMENT = 1;
ALTER TABLE `Kovos_duomenys` AUTO_INCREMENT = 1;
ALTER TABLE `Treneriai` AUTO_INCREMENT = 1;
ALTER TABLE `Kovotojai` AUTO_INCREMENT = 1;
ALTER TABLE `Svorio_Kategorija` AUTO_INCREMENT = 1;

SET FOREIGN_KEY_CHECKS=1;

INSERT INTO `Lytis` (`id`, `name`) VALUES
(1, 'Vyras'),
(2, 'Moteris'),
(3, 'Jauniai'),
(4, 'Jaunės'),
(5, 'Veteranai'),
(6, 'Veteranės'),
(7, 'Atvira'),
(8, 'Mėgėjai'),
(9, 'Profesionalai'),
(10, 'Kita');

INSERT INTO `Kovos_Statusas` (`id`, `name`) VALUES
(1, 'Planuojama'),
(2, 'Įvyko'),
(3, 'Atšaukta'),
(4, 'Perkelta'),
(5, 'Neįvyko'),
(6, 'Nutraukta'),
(7, 'Vėluoja'),
(8, 'Patvirtinta'),
(9, 'Laukiama'),
(10, 'Uždaryta');

INSERT INTO `Kovos_Pabaigos_Tipai` (`id`, `name`) VALUES
(1, 'Nokautas'),
(2, 'Techninis nokautas'),
(3, 'Pasidavimas'),
(4, 'Teisėjų sprendimas'),
(5, 'Diskvalifikacija'),
(6, 'Medicininis stabdymas'),
(7, 'Kova neįvyko'),
(8, 'Lygiosios'),
(9, 'No contest'),
(10, 'Kita');

INSERT INTO `Kovos_Taisykliu_tipai` (`id`, `name`) VALUES
(1, 'MMA'),
(2, 'Boksas'),
(3, 'Kikboksas'),
(4, 'Muay Thai'),
(5, 'K-1'),
(6, 'Grappling'),
(7, 'Judo'),
(8, 'Karate'),
(9, 'Sambo'),
(10, 'Taekwondo');

INSERT INTO `Laimejimo_Rezultatas` (`id`, `name`) VALUES
(1, 'Pergalė'),
(2, 'Pralaimėjimas'),
(3, 'Lygiosios'),
(4, 'Kova neįvyko'),
(5, 'No contest'),
(6, 'Pergalė teisėjų sprendimu'),
(7, 'Pergalė nokautu'),
(8, 'Pergalė pasidavimu'),
(9, 'Diskvalifikacija'),
(10, 'Kita');

INSERT INTO `Narystes_tipai` (`id`, `name`) VALUES
(1, 'Pilna narystė'),
(2, 'Laikina narystė'),
(3, 'Sutartinė narystė'),
(4, 'Mėnesinė narystė'),
(5, 'Metinė narystė'),
(6, 'Studento narystė'),
(7, 'Profesionali narystė'),
(8, 'Vaikų grupė'),
(9, 'Suaugusių grupė'),
(10, 'Individuali programa');

INSERT INTO `Statuso_tipai` (`id`, `name`) VALUES
(1, 'Aktyvus'),
(2, 'Sustabdyta'),
(3, 'Pasibaigusi'),
(4, 'Naujas'),
(5, 'Traumuotas'),
(6, 'Neaktyvus'),
(7, 'Pertraukoje'),
(8, 'Išvykęs'),
(9, 'Baigė karjerą'),
(10, 'Kita');

INSERT INTO `Tasku_sistema` (`id`, `name`) VALUES
(1, '10-point must'),
(2, '3 teisėjų sistema'),
(3, 'Vieno teisėjo sistema'),
(4, 'Round-by-round'),
(5, 'Open scoring'),
(6, 'Hybrid scoring'),
(7, 'Submission prioritetas'),
(8, 'Strike prioritetas'),
(9, 'Taškų vidurkis'),
(10, 'Kita sistema');

INSERT INTO `Kovinio_Sporto_sales` (`Klubo_Pavadinimas`, `Miestas`, `Salis`, `Adresas`, `Telefono_nr`) VALUES
('Sparta Gym', 'Kaunas', 'Lietuva', 'Savanorių pr. 100', '+37060000001'),
('Iron Wolf Club', 'Vilnius', 'Lietuva', 'Žalgirio g. 15', '+37060000002'),
('Titanas Fight House', 'Klaipėda', 'Lietuva', 'Taikos pr. 44', '+37060000003'),
('Baltic Warriors', 'Šiauliai', 'Lietuva', 'Tilžės g. 9', '+37060000004'),
('Kovos Akademija', 'Panevėžys', 'Lietuva', 'Respublikos g. 21', '+37060000005'),
('Ares Team', 'Alytus', 'Lietuva', 'Naujoji g. 12', '+37060000006'),
('Gladiator Gym', 'Marijampolė', 'Lietuva', 'Sporto g. 5', '+37060000007'),
('Samurajus Club', 'Utena', 'Lietuva', 'J. Basanavičiaus g. 18', '+37060000008'),
('Nemunas Fight Center', 'Kaunas', 'Lietuva', 'Karaliaus Mindaugo pr. 7', '+37060000009'),
('Vilnius Combat House', 'Vilnius', 'Lietuva', 'Konstitucijos pr. 33', '+37060000010');

INSERT INTO `Kovotojai` (`id`, `Vardas`, `Pavarde`, `Gimimo_metai`, `Svoris_kg`, `Ugis_cm`) VALUES
(1, 'Mantas', 'Jankauskas', '1997-02-12', 70.4, 176),
(2, 'Lukas', 'Petrauskas', '1995-06-01', 77.1, 181),
(3, 'Tomas', 'Kazlauskas', '1998-09-14', 83.9, 185),
(4, 'Dovydas', 'Urbonas', '1996-01-20', 65.8, 172),
(5, 'Karolis', 'Vaitkus', '1999-03-08', 72.3, 178),
(6, 'Rokas', 'Mikalauskas', '1994-11-19', 79.6, 183),
(7, 'Paulius', 'Brazaitis', '2000-04-27', 68.0, 174),
(8, 'Eimantas', 'Šimkus', '1993-07-03', 90.2, 189),
(9, 'Dominykas', 'Noreika', '1998-12-10', 75.0, 180),
(10, 'Aistis', 'Butkus', '1996-05-16', 84.5, 186);

INSERT INTO `Renginys` (`Renginio_Pavadinimas`, `Renginio_Data`, `Vieta_adresas`, `Miestas`, `Organizatorius`) VALUES
('Baltic Fight Night 1', '2026-02-10', 'Žalgirio arena', 'Kaunas', 'Baltic Fight League'),
('Vilnius Open Combat', '2026-02-24', 'Compensa arena', 'Vilnius', 'Lithuania Combat Org'),
('Klaipėda Championship', '2026-03-05', 'Švyturio arena', 'Klaipėda', 'West Coast Fighting'),
('Šiauliai Fight Cup', '2026-03-12', 'Sporto rūmai', 'Šiauliai', 'North Fight Team'),
('Panevėžys Grand Prix', '2026-03-20', 'Cido arena', 'Panevėžys', 'Pan Fight Promotion'),
('Alytus Arena Clash', '2026-03-28', 'Alytaus arena', 'Alytus', 'Dzūkija Combat'),
('Kaunas MMA Series', '2026-04-06', 'Girstučio salė', 'Kaunas', 'Sparta Events'),
('Vilnius Title Event', '2026-04-14', 'Twinsbet arena', 'Vilnius', 'Iron Wolf Promotion'),
('Baltic Warriors Gala', '2026-04-22', 'Švyturio arena', 'Klaipėda', 'Baltic Warriors'),
('Spring Combat Finals', '2026-04-30', 'Žalgirio arena', 'Kaunas', 'Fight Finals LT');

INSERT INTO `Svorio_Kategorija` (`id`, `Sporto_Saka`, `Kategorijos_Pavadinimas`, `Min_kg`, `Max_kg`, `Amziaus_Grupe`, `Lyties_Grupe`) VALUES
(1, 'MMA', 'Musės svoris', 56.0, 57.0, 1, 1),
(2, 'MMA', 'Gaidžio svoris', 57.1, 61.0, 1, 1),
(3, 'MMA', 'Plunksnos svoris', 61.1, 66.0, 1, 1),
(4, 'MMA', 'Lengvas svoris', 66.1, 70.0, 1, 1),
(5, 'MMA', 'Pusvidutinis svoris', 70.1, 77.0, 1, 1),
(6, 'MMA', 'Vidutinis svoris', 77.1, 84.0, 1, 1),
(7, 'MMA', 'Pussunkis svoris', 84.1, 93.0, 1, 1),
(8, 'MMA', 'Sunkus svoris', 93.1, 120.0, 1, 1),
(9, 'MMA', 'Moterų šiaudų svoris', 48.0, 52.0, 1, 2),
(10, 'MMA', 'Moterų lengvas svoris', 52.1, 57.0, 1, 2);

INSERT INTO `Kovos_Taisykles` (`Taisykliu_pavadinimas`, `Raundu_Skaičius`, `Raundo_Trukme_min`, `Kovos_Taisykles`, `Taskų_sistema`) VALUES
('MMA Pro Rules', 3, 5, 1, 1),
('MMA Title Rules', 5, 5, 1, 1),
('Kickboxing Rules', 3, 3, 3, 2),
('Boxing Rules', 10, 3, 2, 2),
('Muay Thai Rules', 5, 3, 4, 2),
('Amateur MMA Rules', 3, 3, 1, 1),
('Grappling Rules', 1, 10, 6, 7),
('Karate Full Contact', 3, 3, 8, 3),
('Sambo Combat Rules', 3, 5, 9, 6),
('Olympic Taekwondo', 3, 2, 10, 4);

INSERT INTO `Treneriai` (`id`, `Vardas`, `Pavarde`, `Specializacija`, `Pareigos`, `Patirtis_metais`, `fk_Kovinio_Sporto_sales`) VALUES
(1, 'Darius', 'Maciulis', 'MMA Grappling', 'Vyr. treneris', 12, 'Sparta Gym'),
(2, 'Andrius', 'Valenta', 'Striking', 'Treneris', 8, 'Iron Wolf Club'),
(3, 'Evaldas', 'Rimkus', 'BJJ', 'Treneris', 10, 'Titanas Fight House'),
(4, 'Saulius', 'Kairys', 'Boksas', 'Vyr. treneris', 15, 'Baltic Warriors'),
(5, 'Vytautas', 'Norkus', 'Kickboxing', 'Treneris', 9, 'Kovos Akademija'),
(6, 'Mindaugas', 'Juška', 'Muay Thai', 'Treneris', 11, 'Ares Team'),
(7, 'Edgaras', 'Stasiulis', 'Wrestling', 'Treneris', 7, 'Gladiator Gym'),
(8, 'Martynas', 'Lukošius', 'Fizinis rengimas', 'Kondicijos treneris', 13, 'Samurajus Club'),
(9, 'Deividas', 'Bagdonas', 'MMA', 'Treneris', 6, 'Nemunas Fight Center'),
(10, 'Arnoldas', 'Bielskis', 'Technika ir taktika', 'Vyr. treneris', 14, 'Vilnius Combat House');

INSERT INTO `Kovos_duomenys` (`id`, `Kovos_Eile`, `Tituline_kova`, `Pastabos`, `Kovos_laikas_data`, `Kovos_statutas`, `fk_Svorio_Kategorija`, `fk_Renginys`, `fk_Kovos_Taisykles`) VALUES
(1, 1, 1, 'Vakaro pagrindinė kova', '2026-02-10 21:00:00', 2, 5, 'Baltic Fight Night 1', 'MMA Title Rules'),
(2, 2, 0, 'Antra pagrindinė kova', '2026-02-10 20:15:00', 2, 4, 'Baltic Fight Night 1', 'MMA Pro Rules'),
(3, 1, 1, 'Titulinė dvikova', '2026-02-24 21:30:00', 1, 6, 'Vilnius Open Combat', 'MMA Title Rules'),
(4, 2, 0, 'Perspektyvių kovotojų kova', '2026-02-24 19:45:00', 1, 3, 'Vilnius Open Combat', 'MMA Pro Rules'),
(5, 1, 0, 'Pagrindinė vakaro kova', '2026-03-05 20:50:00', 2, 7, 'Klaipėda Championship', 'MMA Pro Rules'),
(6, 1, 0, 'Sportinė dvikova', '2026-03-12 19:30:00', 2, 2, 'Šiauliai Fight Cup', 'Kickboxing Rules'),
(7, 1, 1, 'Čempiono diržo kova', '2026-03-20 21:10:00', 1, 8, 'Panevėžys Grand Prix', 'MMA Title Rules'),
(8, 1, 0, 'Techninė kova', '2026-03-28 20:00:00', 2, 5, 'Alytus Arena Clash', 'MMA Pro Rules'),
(9, 1, 0, 'Atrankinė kova', '2026-04-06 19:20:00', 1, 4, 'Kaunas MMA Series', 'Amateur MMA Rules'),
(10, 1, 1, 'Finalinė vakaro kova', '2026-04-14 21:40:00', 1, 6, 'Vilnius Title Event', 'MMA Title Rules');

INSERT INTO `Kovos_raundo_info` (`id`, `Raundo_Numeris`, `Raundo_Trukme_min`, `Raundo_Trukme_sek`, `Pastabos`, `Raundo_Pabaiga`, `fk_Kovos_duomenys`) VALUES
(1, 5, 5, 0, 'Pilna distancija', 4, 1),
(2, 3, 4, 12, 'Pergalė teisėjų sprendimu', 4, 2),
(3, 0, 0, 0, 'Kova dar neįvyko', 7, 3),
(4, 0, 0, 0, 'Kova dar neįvyko', 7, 4),
(5, 2, 3, 21, 'Techninis nokautas', 2, 5),
(6, 3, 3, 0, 'Pilna distancija', 4, 6),
(7, 0, 0, 0, 'Laukiama renginio', 7, 7),
(8, 3, 5, 0, 'Pergalė taškais', 4, 8),
(9, 0, 0, 0, 'Planuojama kova', 7, 9),
(10, 0, 0, 0, 'Pagrindinė finalo kova', 7, 10);

INSERT INTO `Kovotojo_sporto_saliu_istorija` (`id`, `Narystes_Pradzia`, `Narystes_Pabaiga`, `Pastabos`, `Narystes_tipas`, `Statusas`, `fk_Kovotojai`, `fk_Kovinio_Sporto_sales`) VALUES
(1, '2024-01-01', '2026-12-31', 'Pagrindinis klubo narys', 1, 1, 1, 'Sparta Gym'),
(2, '2024-05-01', '2026-05-01', 'Pasirengimo stovykla', 2, 1, 2, 'Iron Wolf Club'),
(3, '2023-09-01', '2026-09-01', 'Profesionali sutartis', 3, 1, 3, 'Titanas Fight House'),
(4, '2025-01-15', '2026-01-15', 'Metinė narystė', 5, 1, 4, 'Baltic Warriors'),
(5, '2024-03-10', '2026-03-10', 'Sportinė grupė', 9, 1, 5, 'Kovos Akademija'),
(6, '2024-08-20', '2026-08-20', 'Treniruočių planas', 10, 1, 6, 'Ares Team'),
(7, '2024-11-01', '2026-11-01', 'Mėgėjų programa', 4, 1, 7, 'Gladiator Gym'),
(8, '2025-02-01', '2026-02-01', 'Kondicinis rengimas', 6, 1, 8, 'Samurajus Club'),
(9, '2024-06-12', '2026-06-12', 'Varžybinė komanda', 7, 1, 9, 'Nemunas Fight Center'),
(10, '2024-04-04', '2026-04-04', 'Aukšto meistriškumo grupė', 8, 1, 10, 'Vilnius Combat House');

INSERT INTO `Kovotojo_Dalyvavimas` (`id`, `Baigties_raundas`, `Baigties_laikas_min`, `Baigties_laikas_sek`, `Baigties_Budas`, `Rezultatas`, `fk_Kovos_duomenys`, `fk_Kovotojai`) VALUES
(1, 5, 5, 0, 4, 1, 1, 1),
(2, 5, 5, 0, 4, 2, 1, 2),
(3, 3, 4, 12, 4, 1, 2, 3),
(4, 3, 4, 12, 4, 2, 2, 4),
(5, 0, 0, 0, 7, 4, 3, 5),
(6, 0, 0, 0, 7, 4, 3, 6),
(7, 0, 0, 0, 7, 4, 4, 7),
(8, 0, 0, 0, 7, 4, 4, 8),
(9, 2, 3, 21, 2, 1, 5, 9),
(10, 2, 3, 21, 2, 2, 5, 10),
(11, 3, 3, 0, 4, 1, 6, 1),
(12, 3, 3, 0, 4, 2, 6, 3),
(13, 0, 0, 0, 7, 4, 7, 2),
(14, 0, 0, 0, 7, 4, 7, 4),
(15, 3, 5, 0, 4, 1, 8, 5),
(16, 3, 5, 0, 4, 2, 8, 6),
(17, 0, 0, 0, 7, 4, 9, 7),
(18, 0, 0, 0, 7, 4, 9, 8),
(19, 0, 0, 0, 7, 4, 10, 9),
(20, 0, 0, 0, 7, 4, 10, 10);