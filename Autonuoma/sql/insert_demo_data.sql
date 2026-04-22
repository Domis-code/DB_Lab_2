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

INSERT INTO `Lytis` (`id`, `name`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n, CASE WHEN n = 1 THEN 'Vyras' WHEN n = 2 THEN 'Moteris' ELSE CONCAT('Lytis ', n) END
FROM seq;

INSERT INTO `Kovos_Statusas` (`id`, `name`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       CASE
           WHEN n = 1 THEN 'Planuojama'
           WHEN n = 2 THEN 'Ivykusi'
           WHEN n = 3 THEN 'Atsaukta'
           ELSE CONCAT('Statusas ', n)
       END
FROM seq;

INSERT INTO `Kovos_Pabaigos_Tipai` (`id`, `name`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       CASE
           WHEN n = 1 THEN 'Nokautas'
           WHEN n = 2 THEN 'Techninis nokautas'
           WHEN n = 3 THEN 'Pasidavimas'
           WHEN n = 4 THEN 'Taskai'
           WHEN n = 5 THEN 'Kova neivyko'
           ELSE CONCAT('Baigtis ', n)
       END
FROM seq;

INSERT INTO `Kovos_Taisykliu_tipai` (`id`, `name`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       CASE
           WHEN n = 1 THEN 'MMA'
           WHEN n = 2 THEN 'Boksas'
           WHEN n = 3 THEN 'Kikboksas'
           WHEN n = 4 THEN 'Muay Thai'
           ELSE CONCAT('Taisykliu tipas ', n)
       END
FROM seq;

INSERT INTO `Laimejimo_Rezultatas` (`id`, `name`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       CASE
           WHEN n = 1 THEN 'Pergale'
           WHEN n = 2 THEN 'Pralaimejimas'
           WHEN n = 3 THEN 'Lygiosios'
           WHEN n = 4 THEN 'Kova neivyko'
           ELSE CONCAT('Rezultatas ', n)
       END
FROM seq;

INSERT INTO `Narystes_tipai` (`id`, `name`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       CASE
           WHEN n = 1 THEN 'Pilna naryste'
           WHEN n = 2 THEN 'Laikina naryste'
           WHEN n = 3 THEN 'Sutartine naryste'
           ELSE CONCAT('Narystes tipas ', n)
       END
FROM seq;

INSERT INTO `Statuso_tipai` (`id`, `name`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       CASE
           WHEN n = 1 THEN 'Aktyvus'
           WHEN n = 2 THEN 'Sustabdyta'
           WHEN n = 3 THEN 'Pasibaigusi'
           ELSE CONCAT('Statusas ', n)
       END
FROM seq;

INSERT INTO `Tasku_sistema` (`id`, `name`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       CASE WHEN n = 1 THEN '10-point must' ELSE CONCAT('Tasku sistema ', n) END
FROM seq;

INSERT INTO `Kovinio_Sporto_sales` (`Klubo_Pavadinimas`, `Miestas`, `Salis`, `Adresas`, `Telefono_nr`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT CONCAT('Sporto sale ', n),
       CONCAT('Miestas ', n),
       'Lietuva',
       CONCAT('Adresas ', n),
       CONCAT('+3706000', LPAD(n, 4, '0'))
FROM seq;

INSERT INTO `Kovotojai` (`id`, `Vardas`, `Pavarde`, `Gimimo_metai`, `Svoris_kg`, `Ugis_cm`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       CONCAT('Kovotojas', n),
       CONCAT('Pavarde', n),
       DATE_ADD('1990-01-01', INTERVAL n * 180 DAY),
       60 + n,
       165 + (n % 20)
FROM seq;

INSERT INTO `Renginys` (`Renginio_Pavadinimas`, `Renginio_Data`, `Vieta_adresas`, `Miestas`, `Organizatorius`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT CONCAT('Renginys ', n),
       DATE_ADD('2026-01-01', INTERVAL n DAY),
       CONCAT('Arena ', n),
       CONCAT('Miestas ', n),
       CONCAT('Organizatorius ', n)
FROM seq;

INSERT INTO `Svorio_Kategorija` (`id`, `Sporto_Saka`, `Kategorijos_Pavadinimas`, `Min_kg`, `Max_kg`, `Amziaus_Grupe`, `Lyties_Grupe`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       'MMA',
       CONCAT('Kategorija ', n),
       50 + n,
       51 + n,
       1,
       IF(n % 2 = 0, 2, 1)
FROM seq;

INSERT INTO `Kovos_Taisykles` (`Taisykliu_pavadinimas`, `Raundu_Skaičius`, `Raundo_Trukme_min`, `Kovos_Taisykles`, `Taskų_sistema`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT CONCAT('Taisykles ', n),
       IF(n % 2 = 0, 5, 3),
       5,
       ((n - 1) % 25) + 1,
       ((n - 1) % 25) + 1
FROM seq;

INSERT INTO `Treneriai` (`id`, `Vardas`, `Pavarde`, `Specializacija`, `Pareigos`, `Patirtis_metais`, `fk_Kovinio_Sporto_sales`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       CONCAT('Treneris', n),
       CONCAT('Pavarde', n),
       CONCAT('Specializacija ', n),
       'Treneris',
       3 + (n % 15),
       CONCAT('Sporto sale ', n)
FROM seq;

INSERT INTO `Kovos_duomenys` (`id`, `Kovos_Eile`, `Tituline_kova`, `Pastabos`, `Kovos_laikas_data`, `Kovos_statutas`, `fk_Svorio_Kategorija`, `fk_Renginys`, `fk_Kovos_Taisykles`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       n,
       IF(n % 5 = 0, 1, 0),
       CONCAT('Kovos pastaba ', n),
       DATE_ADD('2026-02-01 18:00:00', INTERVAL n HOUR),
       ((n - 1) % 3) + 1,
       n,
       CONCAT('Renginys ', n),
       CONCAT('Taisykles ', n)
FROM seq;

INSERT INTO `Kovos_raundo_info` (`id`, `Raundo_Numeris`, `Raundo_Trukme_min`, `Raundo_Trukme_sek`, `Pastabos`, `Raundo_Pabaiga`, `fk_Kovos_duomenys`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       IF(n % 5 = 0, 5, 3),
       5,
       0,
       CONCAT('Raundo pastaba ', n),
       ((n - 1) % 5) + 1,
       n
FROM seq;

INSERT INTO `Kovotojo_sporto_saliu_istorija` (`id`, `Narystes_Pradzia`, `Narystes_Pabaiga`, `Pastabos`, `Narystes_tipas`, `Statusas`, `fk_Kovotojai`, `fk_Kovinio_Sporto_sales`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n,
       DATE_ADD('2025-01-01', INTERVAL n DAY),
       DATE_ADD('2026-01-01', INTERVAL n DAY),
       CONCAT('Istorijos pastaba ', n),
       ((n - 1) % 3) + 1,
       ((n - 1) % 3) + 1,
       n,
       CONCAT('Sporto sale ', n)
FROM seq;

INSERT INTO `Kovotojo_Dalyvavimas` (`id`, `Baigties_raundas`, `Baigties_laikas_min`, `Baigties_laikas_sek`, `Baigties_Budas`, `Rezultatas`, `fk_Kovos_duomenys`, `fk_Kovotojai`)
WITH RECURSIVE seq AS (SELECT 1 AS n UNION ALL SELECT n + 1 FROM seq WHERE n < 25)
SELECT n, 3, 4, 20, 4, 1, n, n
FROM seq
UNION ALL
SELECT n + 25, 3, 4, 20, 4, 2, n, IF(n < 25, n + 1, 1)
FROM seq;