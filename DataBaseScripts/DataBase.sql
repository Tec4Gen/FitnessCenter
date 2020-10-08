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
	[Login] NVARCHAR(50) UNIQUE NOT NULL,
	[HashPassword] VARBINARY(MAX) NOT NULL,
	RoleWebSite INT NULL DEFAULT 1,
	Avatar NVARCHAR(MAX) NULL
	)
GO
ALTER TABLE [User]
	ADD CONSTRAINT FK_User_RoleWebSite_Id FOREIGN KEY (RoleWebSite)
		REFERENCES [RoleWebSite](Id)
	ON UPDATE CASCADE
	ON DELETE SET NULL
GO

CREATE PROCEDURE [dbo].[CheckUser]
	@Login NVARCHAR(50),
	@HashPassword NVARCHAR(50)
AS	
BEGIN
	SELECT [Login],HashPassword
	FROM [User]
	WHERE  @Login = [Login] AND @HashPassword = HashPassword;
END
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

CREATE TABLE dbo.[UsersLesson]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	IdUser INT NOT NULL,
	IdLesson INT NOT NULL,
	)
GO

ALTER TABLE [UsersLesson]
	ADD CONSTRAINT FK_UsersLesson_User_ID FOREIGN KEY (IdUser)
		REFERENCES [User](Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO

ALTER TABLE [UsersLesson]
	ADD CONSTRAINT FK_UsersLesson_Lesson_ID FOREIGN KEY (IdLesson)
		REFERENCES Lesson(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO

ALTER TABLE UsersLesson ADD UNIQUE ( IdUser , IdLesson )
--///////////////////////////////////////////////
--                  Hall Table
--///////////////////////////////////////////////
CREATE TABLE dbo.[Hall]
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NameHall NVARCHAR(50) UNIQUE NOT NULL
	)
GO

ALTER TABLE [Lesson]
	ADD CONSTRAINT FK_Lesson_Hall_ID FOREIGN KEY (IdHall)
		REFERENCES Hall(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO


--///////////////////////////////////////////////
--          StorageProcedure User
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetUserById]
	@Id INT
AS
BEGIN
     SELECT	Id, FirstName, LastName, MiddleName, RoleWebSite, Avatar
	 FROM [User]
     WHERE (@Id = Id )
END
GO

CREATE PROCEDURE [dbo].[GetUserByRole]
	@IdRole INT
AS
BEGIN
     SELECT	Id, FirstName, LastName, MiddleName, RoleWebSite, Avatar
	 FROM [User]
     WHERE (@IdRole = RoleWebSite )
END
GO

CREATE PROCEDURE [dbo].[InsertUser]

    @FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@MiddleName NVARCHAR(50),
	@Login NVARCHAR(50),
	@HashPassword VARBINARY(MAX),
	@RoleWebSite INT,
	@Avatar VARBINARY(MAX) = NULL
AS
BEGIN	
	INSERT INTO [User](FirstName,LastName,MiddleName,[Login],HashPassword, RoleWebSite, Avatar)
	VALUES (@FirstName, @LastName, @MiddleName, @Login, @HashPassword, @RoleWebSite, @Avatar)
END
GO

CREATE PROCEDURE [dbo].[DeleteUser]
	@Id INT
AS	
BEGIN
	DELETE FROM [User]
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[UpdateUser]
	@Id INT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@MiddleName NVARCHAR(50),
	@RoleWebSite INT,
	@Avatar VARBINARY(MAX) = NULL
AS
BEGIN
	UPDATE [User] SET FirstName = @FirstName,LastName = @LastName, MiddleName = @MiddleName, RoleWebSite = @RoleWebSite, Avatar = @Avatar
	FROM [User]
	WHERE (@Id = Id)
END
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
     SELECT Id, FirstName, LastName, MiddleName, [RoleWebSite]
	 FROM [User] 
END
GO

--///////////////////////////////////////////////
--          StorageProcedure Lesson
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetLessonById]
	@Id INT
AS
BEGIN
     SELECT	Id,	IdUserCoach, IdHall, [DateTime], [Description]
	 FROM Lesson
     WHERE (@Id = Id )
END
GO

CREATE PROCEDURE [dbo].[InsertLesson]

    @IdUserCoach INT,
	@IdHall INT,
	@DateTime DATETIME2,
	@Description NVARCHAR(50)
AS
BEGIN	
	INSERT INTO Lesson (IdUserCoach,IdHall,[DateTime],[Description])
	VALUES (@IdUserCoach, @IdHall, @DateTime, @Description)
END
GO


CREATE PROCEDURE [dbo].[DeleteLesson]
	@Id INT
AS	
BEGIN
	DELETE FROM Lesson
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[UpdateLesson]
	@Id INT,
	@IdUserCoach INT,
	@IdHall INT,
	@DateTime DATETIME2,
	@Description NVARCHAR(50)
AS
BEGIN
	UPDATE Lesson SET IdUserCoach = @IdUserCoach, IdHall = @IdHall, [DateTime] = @DateTime, [Description] = @Description
	FROM Lesson
	WHERE (@Id = Id)
END
GO


CREATE PROCEDURE [dbo].[GetAllLessons]
AS
BEGIN
     SELECT Id, IdUserCoach, IdHall, [DateTime], [Description]
	 FROM Lesson 
END
GO

--///////////////////////////////////////////////
--          StorageProcedure UsersLesson
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetUsersLessonById]
	@Id INT
AS
BEGIN
     SELECT	Id,	IdUser, IdLesson
	 FROM UsersLesson
     WHERE (@Id = Id)
END
GO

CREATE PROCEDURE [dbo].[GetAllLessonsByIdUser]
    @IdUser INT
AS
BEGIN	
	SELECT	Id,	IdUser, IdLesson
	 FROM UsersLesson
     WHERE (@IdUser = IdUser)
END
GO

CREATE PROCEDURE [dbo].[GetAllUsersByIdLesson]
    @IdLesson INT
AS
BEGIN	
	SELECT	Id,	IdUser, IdLesson
	 FROM UsersLesson
     WHERE (@IdLesson = IdLesson)
END
GO

CREATE PROCEDURE [dbo].[InsertUsersLesson]

    @IdUser INT,
	@IdLesson INT
AS
BEGIN	
	INSERT INTO UsersLesson (IdUser,IdLesson)
	VALUES (@IdUser, @IdLesson)
END
GO

CREATE PROCEDURE [dbo].[DeleteUsersLesson]
	@Id INT
AS	
BEGIN
	DELETE FROM UsersLesson
	WHERE Id = @Id;
END
GO

--///////////////////////////////////////////////
--          StorageProcedure Hall
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetHallById]
	@Id INT
AS
BEGIN
     SELECT	Id,	NameHall
	 FROM Hall
     WHERE (@Id = Id)
END
GO

CREATE PROCEDURE [dbo].[InsertHall]
	@Name NVARCHAR(50)
AS
BEGIN	
	INSERT INTO Hall (NameHall)
	VALUES (@Name)
END
GO

CREATE PROCEDURE [dbo].[DeleteHall]
	@Id INT
AS	
BEGIN
	DELETE FROM Hall
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[GetAllHall]
AS
BEGIN
     SELECT Id, NameHall
	 FROM Hall 
END
GO

--///////////////////////////////////////////////
--          StorageProcedure RoleWebSite
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetAllRole]
AS
BEGIN
     SELECT Id, [Name]
	 FROM RoleWebSite 
END
GO

CREATE PROCEDURE [dbo].[GetRoleById]
	@Id INT
AS
BEGIN
     SELECT Id, [Name]
	 FROM RoleWebSite 
	 WHERE @Id = Id
END
GO


CREATE PROCEDURE [dbo].[GetRolesForUser]
	@UserName NVARCHAR(50)
AS
BEGIN

SELECT rol.[Name]
FROM [User]
 INNER JOIN RoleWebSite rol
 ON [User].RoleWebSite = rol.Id;
     
END
GO




