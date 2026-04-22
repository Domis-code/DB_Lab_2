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



