-- Cr�ation de la DB
USE MASTER;
GO
DROP DATABASE IF EXISTS GoodSwapCardDB
GO
CREATE DATABASE GoodSwapCardDB;
GO
USE GoodSwapCardDB
GO

-- Cr�ation des tables
--Table Statut
CREATE TABLE Statut (
	Id int IDENTITY(1,1) Primary Key,
	StatutName varchar(50) NOT NULL
);

--Table StatutEvent
CREATE TABLE StatutEvent (
	Id int IDENTITY(1,1) Primary Key,
	StatutEventName varchar(50) NOT NULL
);

--Table Pays
CREATE TABLE Country (
	Id int IDENTITY(1,1) Primary Key,
	CountryName varchar (50) NOT NULL
);

--Table Localit�
CREATE TABLE Locality (
	Id int IDENTITY(1,1) Primary Key,
	LocalityName varchar (50) NOT NULL,
	CP varchar (10) NOT NULL,
	IdCountry int NOT NULL CONSTRAINT FK_Country FOREIGN KEY (IdCountry) REFERENCES Country (Id)
);

--Table Utilisateurs
CREATE TABLE Utils (
	Id int IDENTITY(1,1) Primary Key,
	LastName varchar(50) NOT NULL,
	FirstName varchar(50) NOT NULL,
	PsW varchar(256) NOT NULL,
	Email varchar(100) UNIQUE NOT NULL,
	Phone varchar(20),
	Birthdate DateTime, 
	IdStatut int NOT NULL CONSTRAINT FK_Statut_User FOREIGN KEY (IdStatut) REFERENCES Statut (Id)
);

--Table Society
CREATE TABLE Society (
	Id int IDENTITY(1,1) Primary Key,
	SocietyName varchar(50) NOT NULL,
	SocietyDesc text,
	Phone varchar(20),
	IdLoc int NOT NULL CONSTRAINT FK_Loc FOREIGN KEY (IdLoc) REFERENCES Locality (Id),
	IdBoss int NOT NULL CONSTRAINT FK_Boss FOREIGN KEY (IdBoss) REFERENCES Utils (Id)
);

--Table SocietyUser
CREATE TABLE SocietyUser (
	Id int IDENTITY(1,1) Primary Key,
	IdUser int NOT NULL CONSTRAINT FK_UserSociety FOREIGN KEY (IdUser) REFERENCES Utils (Id),
	IdSociety int NOT NULL CONSTRAINT FK_Society FOREIGN KEY (IdSociety) REFERENCES Society (Id)
);

--Table Place
CREATE TABLE Place (
	Id int IDENTITY(1,1) Primary Key,
	PlaceName varchar(50) NOT NULL,
	Street varchar(50) NOT NULL,
	Number varchar(5) NOT NULL,
	IdLoc int NOT NULL CONSTRAINT FK_Locality FOREIGN KEY (IdLoc) REFERENCES Locality (Id)
);

--Table Event
CREATE TABLE Evenement (
	Id int IDENTITY(1,1) Primary Key,
	EvenementName varchar(50) NOT NULL,
	EventDesc text,
	DateEvent DateTime NOT NUll,
	IdUserCreator int NOT NULL CONSTRAINT FK_UserCreator FOREIGN KEY (IdUserCreator) REFERENCES Utils (Id),
	IdPlace int NOT NULL CONSTRAINT FK_Place FOREIGN KEY (IdPlace) REFERENCES Place (Id)
);

--Table EventUser
CREATE TABLE EventUser (
	Id int IDENTITY(1,1) Primary Key,
	IdUser int NOT NULL CONSTRAINT FK_User FOREIGN KEY (IdUser) REFERENCES Utils (Id),
	IdEvent int NOT NULL  CONSTRAINT FK_Event FOREIGN KEY (IdEvent) REFERENCES Evenement (Id),
	IdStatutEvent int NOT NULL CONSTRAINT FK_StatutEvent FOREIGN KEY (IdStatutEvent) REFERENCES StatutEvent (Id)
);

--Table Heure
CREATE TABLE HourTime (
	Id int IDENTITY(1,1) Primary Key,
	[Hour] int NOT NULL,
	[Minute] int NOT NULL
);

--Table RDV
CREATE TABLE RDV (
	Id int IDENTITY(1,1) Primary Key,
	IdHour int NOT NULL CONSTRAINT FK_Hour FOREIGN KEY (IdHour) REFERENCES HourTime (Id),
	IdCandidat int NOT NULL CONSTRAINT FK_Candidat FOREIGN KEY (IdCandidat) REFERENCES Utils (Id),
	IdRep int NOT NULL CONSTRAINT FK_Rep FOREIGN KEY (IdRep) REFERENCES Utils (Id),
	RdvState bit NOT NULL default 0
);

--Table Notifications
CREATE TABLE Notifications(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Content varchar(255) NOT NULL,
	IdUser int NOT NULL CONSTRAINT FK_NotifUser FOREIGN KEY (IdUser) REFERENCES Utils (Id)
);

CREATE TABLE Messagerie(
	Id int IDENTITY(1,1) PRIMARY KEY,
	IdUserOne int NOT NULL CONSTRAINT FK_UserMessOne FOREIGN KEY (IdUserOne) REFERENCES Utils (Id),
	IdUserTwo int NOT NULL CONSTRAINT FK_UserMessTwo FOREIGN KEY (IdUserTwo) REFERENCES Utils (Id),
	Content text,
	DateSend datetime default datetime.NOW()
);

GO

--Populations des tables
--Table Statut
INSERT INTO Statut (StatutName) VALUES ('Admin'); --admin
INSERT INTO Statut (StatutName) VALUES ('Visiteur');

--Table StatutEvent
INSERT INTO StatutEvent (StatutEventName) VALUES ('Modo'); --groupe pour cr�ation/administration des events
INSERT INTO StatutEvent (StatutEventName) VALUES ('Util');

--Table Country
INSERT INTO Country (CountryName) VALUES ('Afghanistan');
INSERT INTO Country (CountryName) VALUES ('Afrique du Sud');
INSERT INTO Country (CountryName) VALUES ('Alg�rie');
INSERT INTO Country (CountryName) VALUES ('Allemagne');
INSERT INTO Country (CountryName) VALUES ('Arabie saoudite');
INSERT INTO Country (CountryName) VALUES ('Argentine');
INSERT INTO Country (CountryName) VALUES ('Belgique');
INSERT INTO Country (CountryName) VALUES ('Burkina Faso');
INSERT INTO Country (CountryName) VALUES ('Canada');
INSERT INTO Country (CountryName) VALUES ('Chine');
INSERT INTO Country (CountryName) VALUES ('Espagne');
INSERT INTO Country (CountryName) VALUES ('�tats-Unis');
INSERT INTO Country (CountryName) VALUES ('France');
INSERT INTO Country (CountryName) VALUES ('Gr�ce');
INSERT INTO Country (CountryName) VALUES ('Hong Kong');
INSERT INTO Country (CountryName) VALUES ('Hongrie');
INSERT INTO Country (CountryName) VALUES ('Iles Cayman');
INSERT INTO Country (CountryName) VALUES ('Irlande');
INSERT INTO Country (CountryName) VALUES ('Islande');
INSERT INTO Country (CountryName) VALUES ('Italie');
INSERT INTO Country (CountryName) VALUES ('Japon');
INSERT INTO Country (CountryName) VALUES ('Luxembourg');
INSERT INTO Country (CountryName) VALUES ('Malte');
INSERT INTO Country (CountryName) VALUES ('Maroc');
INSERT INTO Country (CountryName) VALUES ('Mexique');
INSERT INTO Country (CountryName) VALUES ('Nouvelle-Z�lande');
INSERT INTO Country (CountryName) VALUES ('P�rou');
INSERT INTO Country (CountryName) VALUES ('Paraguay');
INSERT INTO Country (CountryName) VALUES ('Pays-Bas');
INSERT INTO Country (CountryName) VALUES ('Portugal');
INSERT INTO Country (CountryName) VALUES ('Qatar');
INSERT INTO Country (CountryName) VALUES ('R�publique dominicaine');
INSERT INTO Country (CountryName) VALUES ('R�publique tch�que');
INSERT INTO Country (CountryName) VALUES ('R�union');
INSERT INTO Country (CountryName) VALUES ('Royaume-Uni');
INSERT INTO Country (CountryName) VALUES ('Russie');
INSERT INTO Country (CountryName) VALUES ('Rwanda');
INSERT INTO Country (CountryName) VALUES ('Suisse');
INSERT INTO Country (CountryName) VALUES ('Tha�lande');
INSERT INTO Country (CountryName) VALUES ('Tunisie');
INSERT INTO Country (CountryName) VALUES ('Turquie');
INSERT INTO Country (CountryName) VALUES ('Yougoslavie');
INSERT INTO Country (CountryName) VALUES ('Zimbabwe');
INSERT INTO Country (CountryName) VALUES ('Mac�doine');

--Table Locality
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Bruxelles','1000',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Namur','5000',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Gembloux','5030',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Court-Saint-Etienne','1490',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Nivelles','1400',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Cologne','50441',2);

--Table Utilisateurs
INSERT INTO Utils VALUES ('Adnet', 'Geoffroy', 'aqwzsx', 'emaila@mail.be','' ,'', 1);
INSERT INTO Utils VALUES ('Bouillon', 'Jeremy', '123456', 'emailb@mail.be','' ,'', 1);
INSERT INTO Utils VALUES ('Fontesse', 'Axel', '789456', 'emailc@mail.be','' ,'', 1);
INSERT INTO Utils VALUES ('Ghost', 'Man', 'poiuyt', 'emaild@mail.be','' ,'', 2)
INSERT INTO Utils VALUES ('Brasseur', 'Xavier', '9515951', 'emaile@mail.be','' ,'', 2);

--Table Society
INSERT INTO Society VALUES('Genesis Conult','', '023233232',1, 2);
INSERT INTO Society VALUES('Odoo','', '010111111',3,3);
INSERT INTO Society VALUES('Intergraph','', '023233232',1, 1);

--Table SocietyUser
INSERT INTO SocietyUser VALUES (1,2);
INSERT INTO SocietyUser VALUES (2,3);
INSERT INTO SocietyUser VALUES (3,1);

--Table Place
INSERT INTO Place (PlaceName, Street, Number, IdLoc) VALUES ('PAM Expo', 'rue du coin', '5', 4);
INSERT INTO Place (PlaceName, Street, Number, IdLoc) VALUES ('Waux Hall', 'grand place', '2', 5);
INSERT INTO Place (PlaceName, Street, Number, IdLoc) VALUES ('Palais 12', 'plateau du heysel', '12', 1);
INSERT INTO Place (PlaceName, Street, Number, IdLoc) VALUES ('Namur Expo', 'rue du bois', '789', 2);

--Table Heures
INSERT INTO HourTime VALUES (9,0);
INSERT INTO HourTime VALUES (9,15);
INSERT INTO HourTime VALUES (9,30);
INSERT INTO HourTime VALUES (9,45);
INSERT INTO HourTime VALUES (10,0);
INSERT INTO HourTime VALUES (10,15);
INSERT INTO HourTime VALUES (10,30);
INSERT INTO HourTime VALUES (10,45);
INSERT INTO HourTime VALUES (11,0);
INSERT INTO HourTime VALUES (11,15);
INSERT INTO HourTime VALUES (11,30);
INSERT INTO HourTime VALUES (11,45);
INSERT INTO HourTime VALUES (12,0);
INSERT INTO HourTime VALUES (12,15);
INSERT INTO HourTime VALUES (12,30);
INSERT INTO HourTime VALUES (12,45);
INSERT INTO HourTime VALUES (13,0);
INSERT INTO HourTime VALUES (13,15);
INSERT INTO HourTime VALUES (13,30);
INSERT INTO HourTime VALUES (13,45);
INSERT INTO HourTime VALUES (14,0);
INSERT INTO HourTime VALUES (14,15);
INSERT INTO HourTime VALUES (14,30);
INSERT INTO HourTime VALUES (14,45);
INSERT INTO HourTime VALUES (15,0);
INSERT INTO HourTime VALUES (15,15);
INSERT INTO HourTime VALUES (15,30);
INSERT INTO HourTime VALUES (15,45);
INSERT INTO HourTime VALUES (16,0);
INSERT INTO HourTime VALUES (16,15);
INSERT INTO HourTime VALUES (16,30);
INSERT INTO HourTime VALUES (16,45);
INSERT INTO HourTime VALUES (17,0);
INSERT INTO HourTime VALUES (17,15);
INSERT INTO HourTime VALUES (17,30);
INSERT INTO HourTime VALUES (17,45);