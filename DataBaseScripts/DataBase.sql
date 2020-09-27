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
	[Name] NVARCHAR(50) NOT NULL
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
	[HashPassword] NVARCHAR(100) NOT NULL,
	RoleWebSite INT NULL DEFAULT 1,
	)
GO
ALTER TABLE [User]
	ADD CONSTRAINT FK_User_RoleWebSite_Id FOREIGN KEY (RoleWebSite)
		REFERENCES [RoleWebSite](Id)
	ON UPDATE CASCADE
	ON DELETE SET NULL
GO


--///////////////////////////////////////////////
--                  Lesson Table
--///////////////////////////////////////////////

CREATE TABLE dbo.[Lesson]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdUserCoach INT NOT NULL,
	IdHall INT NOT NULL,
	[DateTime] DATETIME2 NOT NULL,
	[Description] NVARCHAR(150) NOT NULL
	)
GO

CREATE TABLE dbo.[UserLesson]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdUser INT NOT NULL,
	IdLesson INT NOT NULL,
	)
GO

ALTER TABLE [UserLesson]
	ADD CONSTRAINT FK_UserLesson_User_ID FOREIGN KEY (IdUser)
		REFERENCES [User](Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO

ALTER TABLE [UserLesson]
	ADD CONSTRAINT FK_UserLesson_Lesson_ID FOREIGN KEY (IdLesson)
		REFERENCES Lesson(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO

--///////////////////////////////////////////////
--                  Hall Table
--///////////////////////////////////////////////
CREATE TABLE dbo.[Hall]
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NameHall NVARCHAR(50) NOT NULL
	)
GO

ALTER TABLE [Lesson]
	ADD CONSTRAINT FK_Lesson_Hall_ID FOREIGN KEY (IdHall)
		REFERENCES Hall(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO
