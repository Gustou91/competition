--
-- Fichier généré par SQLiteStudio v3.1.0sur dim. nov. 13 12:48:59 2016
--
-- Encodage texte utilisé: UTF-8
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: randori
DROP TABLE IF EXISTS randori;
CREATE TABLE randori ( ran_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, ran_membre1 INTEGER REFERENCES membre (mem_id), ran_membre2 INTEGER REFERENCES membre (mem_id) );

-- Table: resultat
DROP TABLE IF EXISTS resultat;
CREATE TABLE resultat ( res_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, res_membre INTEGER REFERENCES membre (mem_id), res_randori INTEGER REFERENCES randori (ran_id), res_victoire BOOLEAN NOT NULL, res_points INT NOT NULL);

-- Table: poule
DROP TABLE IF EXISTS poule;
CREATE TABLE poule (pou_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, pou_nom STRING (10) NOT NULL, pou_creation DATETIME NOT NULL, pou_competition INT REFERENCES competition (com_id) ON DELETE CASCADE ON UPDATE CASCADE, pou_modification DATETIME);

-- Table: competition
DROP TABLE IF EXISTS competition;
CREATE TABLE competition (com_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, com_nom STRING (50) NOT NULL, com_active BOOLEAN NOT NULL, com_creation DATETIME NOT NULL);
INSERT INTO competition (com_id, com_nom, com_active, com_creation) VALUES (2, 'Challenge Noël 2016/2017', 1, '2016-10-02 16:49:10');

-- Table: categorie
DROP TABLE IF EXISTS categorie;
CREATE TABLE categorie (cat_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, cat_nom STRING (50) NOT NULL, cat_agemin INT NOT NULL, cat_agemax INT NOT NULL, cat_sexe CHAR (1) NOT NULL, cat_poidsmin INT NOT NULL, cat_poidsmax INT NOT NULL, cat_creation DATETIME NOT NULL, cat_modification DATETIME);
INSERT INTO categorie (cat_id, cat_nom, cat_agemin, cat_agemax, cat_sexe, cat_poidsmin, cat_poidsmax, cat_creation, cat_modification) VALUES (21, '2004 Fille 27-28kg', 12, 12, 'F', 27, 28, '2016-11-12 14:45:23', '2016-11-13 10:56:04');
INSERT INTO categorie (cat_id, cat_nom, cat_agemin, cat_agemax, cat_sexe, cat_poidsmin, cat_poidsmax, cat_creation, cat_modification) VALUES (24, '2005 Garçon 35-38kg', 11, 11, 'M', 35, 38, '2016-11-13 10:57:20', NULL);
INSERT INTO categorie (cat_id, cat_nom, cat_agemin, cat_agemax, cat_sexe, cat_poidsmin, cat_poidsmax, cat_creation, cat_modification) VALUES (25, '2006 Fille 23-25Kg', 10, 10, 'F', 23, 25, '2016-11-13 11:05:31', NULL);
INSERT INTO categorie (cat_id, cat_nom, cat_agemin, cat_agemax, cat_sexe, cat_poidsmin, cat_poidsmax, cat_creation, cat_modification) VALUES (26, '2006 Garçon 24-25Kg', 10, 10, 'M', 24, 25, '2016-11-13 11:06:42', NULL);

-- Table: membre
DROP TABLE IF EXISTS membre;
CREATE TABLE membre (mem_id INTEGER PRIMARY KEY ON CONFLICT ROLLBACK AUTOINCREMENT, mem_nom STRING (50) NOT NULL, mem_prenom STRING (50) NOT NULL, mem_sexe CHAR (1) NOT NULL, mem_age INT (2) NOT NULL, mem_poids INT (3) NOT NULL, mem_creation DATETIME NOT NULL, mem_modification DATETIME);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (2, 'Garcin', 'HM', 'M', 8, 32, '2016-11-08 00:17:38', '2016-11-13 11:34:58');
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (3, 'Garcin', 'Clarisse', 'F', 3, 22, '2016-11-08 00:18:09', '2016-11-13 11:34:51');
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (4, 'Abimane', 'Hugues', 'M', 100, 23, '2016-11-13 11:20:27', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (5, 'Acher', 'Océane', 'F', 10, 24, '2016-11-13 11:27:19', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (6, 'Afonso', 'Manon', 'F', 12, 27, '2016-11-13 11:41:04', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (7, 'Afonso', 'Ilan', 'M', 6, 19, '2016-11-13 11:41:47', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (8, 'Alphonsout', 'Maely', 'F', 10, 24, '2016-11-13 11:42:38', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (9, 'Ambrosi', 'Enzo', 'M', 10, 25, '2016-11-13 11:43:14', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (10, 'Amistani', 'Leandro', 'M', 10, 21, '2016-11-13 11:43:51', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (11, 'Anne', 'Mathys', 'M', 11, 22, '2016-11-13 11:44:24', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (12, 'Assogba', 'Maelys', 'M', 11, 22, '2016-11-13 11:45:17', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (13, 'Aviez', 'Cédric', 'M', 11, 35, '2016-11-13 11:46:11', '2016-11-13 11:47:01');
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (14, 'Bachelet', 'Loup', 'F', 12, 28, '2016-11-13 11:46:51', NULL);
INSERT INTO membre (mem_id, mem_nom, mem_prenom, mem_sexe, mem_age, mem_poids, mem_creation, mem_modification) VALUES (15, 'Badou', 'Evan', 'M', 11, 38, '2016-11-13 11:47:41', NULL);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
