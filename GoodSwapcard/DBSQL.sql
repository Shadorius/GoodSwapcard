-- Création de la DB
USE MASTER;
GO
DROP DATABASE IF EXISTS GoodSwapCardDB
GO
CREATE DATABASE GoodSwapCardDB;
GO
USE GoodSwapCardDB
GO

-- Création des tables
--Table Utilisateurs
CREATE TABLE Utils (
	Id int IDENTITY(1,1) Primary Key,
	LastName varchar(50) NOT NULL,
	FirstName varchar(50) NOT NULL,
	PsW varchar(256) NOT NULL,
	Email varchar(100) UNIQUE NOT NULL,
	Phone varchar(20),
	Birthdate DateTime 
);

--Table Statut
CREATE TABLE Statut (
	Id int IDENTITY(1,1) Primary Key,
	StatutName varchar(50) NOT NULL
);

--Table Pays
CREATE TABLE Country (
	Id int IDENTITY(1,1) Primary Key,
	CountryName varchar (50) NOT NULL
);

--Table Localité
CREATE TABLE Locality (
	Id int IDENTITY(1,1) Primary Key,
	LocalityName varchar (50) NOT NULL,
	CP varchar (10) NOT NULL,
	IdCountry int NOT NULL CONSTRAINT FK_Country FOREIGN KEY (IdCountry) REFERENCES Country (Id)
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
	DateEvent DateTime NOT NUll,
	IdUserCreator int NOT NULL CONSTRAINT FK_UserCreator FOREIGN KEY (IdUserCreator) REFERENCES Utils (Id),
	IdPlace int NOT NULL CONSTRAINT FK_Place FOREIGN KEY (IdPlace) REFERENCES Place (Id)
);

--Table EventUser
CREATE TABLE EventUser (
	Id int IDENTITY(1,1) Primary Key,
	IdUser int NOT NULL CONSTRAINT FK_User FOREIGN KEY (IdUser) REFERENCES Utils (Id),
	IdEvent int NOT NULL  CONSTRAINT FK_Event FOREIGN KEY (IdEvent) REFERENCES Evenement (Id),
	IdStatut int NOT NULL CONSTRAINT FK_Statut FOREIGN KEY (IdStatut) REFERENCES Statut (Id)
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
);

--Table Notifications
CREATE TABLE Notifications(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Content varchar(255) NOT NULL,
	IdUser int NOT NULL CONSTRAINT FK_NotifUser FOREIGN KEY (IdUser) REFERENCES Utils (Id),
);

GO

--Populations des tables
--Table Utilisateurs
INSERT INTO Utils (LastName, FirstName, PsW, Email) VALUES ('Adnet', 'Geoffroy', 'aqwzsx', 'emaila@mail.be');
INSERT INTO Utils (LastName, FirstName, PsW, Email) VALUES ('Bouillon', 'Jeremy', '123456', 'emailb@mail.be');
INSERT INTO Utils (LastName, FirstName, PsW, Email) VALUES ('Fontesse', 'Axel', '789456', 'emailc@mail.be');
INSERT INTO Utils (LastName, FirstName, PsW, Email) VALUES ('Ghost', 'Man', 'poiuyt', 'emaild@mail.be')
INSERT INTO Utils (LastName, FirstName, PsW, Email) VALUES ('Brasseur', 'Xavier', '9515951', 'emaile@mail.be');

--Table Statut
INSERT INTO Statut (StatutName) VALUES ('Admin'); --admin
INSERT INTO Statut (StatutName) VALUES ('Modo'); --groupe pour création/administration des events
INSERT INTO Statut (StatutName) VALUES ('Util');
INSERT INTO Statut (StatutName) VALUES ('Visiteur');

--Table Country
INSERT INTO Country (CountryName) VALUES ('Belgique');
INSERT INTO Country (CountryName) VALUES ('Allemagne');
INSERT INTO Country (CountryName) VALUES ('Luxembourg');

--Table Locality
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Bruxelles','1000',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Namur','5000',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Gembloux','5030',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Court-Saint-Etienne','1490',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Nivelles','1400',1);
INSERT INTO Locality (LocalityName, CP, IdCountry) VALUES ('Cologne','50441',2);

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