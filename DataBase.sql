USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'FitnessCenter')
BEGIN
	DROP DATABASE FitnessCenter;
END

CREATE DATABASE FitnessCenter
GO

USE FitnessCenter
GO
--///////////////////////////////////////////////
--                  RoleWebSite Table
--///////////////////////////////////////////////
CREATE TABLE dbo.[RoleWebSite]
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Client NVARCHAR(50) NOT NULL,
	Coach NVARCHAR(50) NOT NULL,
	[Admin] NVARCHAR(50) NOT NULL,
	)
GO
--///////////////////////////////////////////////
--                  User Table
--///////////////////////////////////////////////

CREATE TABLE dbo.[User]
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NULL,
	LastName NVARCHAR(50) NULL,
	MiddleName NVARCHAR(50) NULL,
	[Login] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(100) NOT NULL,
	RoleWebSite INT NOT NULL DEFAULT 1,
	[Role] INT NULL
	)
GO
ALTER TABLE [User]
	ADD CONSTRAINT FK_User_RoleWebSite_Id FOREIGN KEY (RoleWebSite)
		REFERENCES [RoleWebSite](Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
--///////////////////////////////////////////////
--                  Client Table
--///////////////////////////////////////////////


CREATE TABLE dbo.[Client]
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SubscriptionNumber NUMERIC(6) UNIQUE  NOT NULL 
	)
GO

CREATE TABLE dbo.[UserClient]
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUser INT NOT NULL,
	IdClient INT NOT NULL
	)
GO

ALTER TABLE UserClient
	ADD CONSTRAINT FK_UserClient_User_Id FOREIGN KEY (IdUser)
		REFERENCES [User](Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE UserClient
	ADD CONSTRAINT FK_UserClient_Client_Id FOREIGN KEY (IdClient)
		REFERENCES Client(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO

--ALTER TABLE Client
--	ADD CONSTRAINT FK_Client_RoleWebSite_Id FOREIGN KEY (Id)
--		REFERENCES RoleWebSite(Id)
--	ON UPDATE CASCADE
--	ON DELETE CASCADE
--GO

--///////////////////////////////////////////////
--                  Coach Table
--///////////////////////////////////////////////


CREATE TABLE dbo.[Coach]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	PasswordCoach NVARCHAR UNIQUE NOT NULL,
	)
GO

CREATE TABLE dbo.[UserCoach]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdUser INT NOT NULL,
	IdCoach INT NOT NULL
	)
GO

ALTER TABLE UserCoach
	ADD CONSTRAINT FK_UserCoach_User_Id FOREIGN KEY (IdUser)
		REFERENCES [User](Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE UserCoach
	ADD CONSTRAINT FK_UserCoach_Coach_Id FOREIGN KEY (IdCoach)
		REFERENCES Coach(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
--///////////////////////////////////////////////
--                  Administrator Table
--///////////////////////////////////////////////

CREATE TABLE dbo.[Admin]
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PasswordAdmin NVARCHAR(50) UNIQUE NOT NULL
	)
GO

CREATE TABLE dbo.[UserAdmin]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdUser INT NOT NULL,
	IdAdmin INT NOT NULL
	)
GO

ALTER TABLE UserAdmin
	ADD CONSTRAINT FK_UserAdmin_User_Id FOREIGN KEY (IdUser)
		REFERENCES [User](Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE UserAdmin
	ADD CONSTRAINT FK_UserAdmin_Admin_Id FOREIGN KEY (IdAdmin)
		REFERENCES [Admin](Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO

--///////////////////////////////////////////////
--                  Hall Table
--///////////////////////////////////////////////
CREATE TABLE dbo.Hall
	(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NameHall NVARCHAR(50) UNIQUE NOT NULL,
	[Description] NVARCHAR(150) NOT NULL DEFAULT 'Описание отсутствует'
	)
GO

CREATE TABLE dbo.Lessons
	(
	IDLessons INT PRIMARY KEY IDENTITY(1,1),
	IDClient INT NOT NULL,
	IDHall INT NOT NULL,
	ClassTime DATETIME NOT NULL,
	)
GO

ALTER TABLE Client
	ADD CONSTRAINT FK_Coach_Client_ID FOREIGN KEY (IDCoach)
		REFERENCES Coach(ID)
		ON DELETE SET NULL
		ON UPDATE CASCADE
GO
ALTER TABLE Lessons
	ADD CONSTRAINT FK_Lessons_Client_ID FOREIGN KEY (IDClient)
		REFERENCES Client(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO
ALTER TABLE Lessons
	ADD CONSTRAINT FK_Lessons_Hall_ID FOREIGN KEY (IDHall)
		REFERENCES Hall(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO