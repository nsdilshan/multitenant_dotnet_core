IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'ClientDb')
BEGIN

	CREATE DATABASE [ClientDb]

END
GO
    USE [ClientDb]
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' and xtype='U')
BEGIN
    CREATE TABLE [dbo].[Users] (
        UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserName VARCHAR(200) NOT NULL,
		Email VARCHAR(200) NOT NULL,
		ClientId VARCHAR(200) NOT NULL
    )
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Products' and xtype='U')
BEGIN
    CREATE TABLE [dbo].[Products] (
        [ProductId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Name] VARCHAR(200) NOT NULL,
		[Description] VARCHAR(200) NOT NULL,
		[Rate] INT NOT NULL,
		ClientId VARCHAR(200) NOT NULL
    )
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Branches' and xtype='U')
BEGIN
    CREATE TABLE [dbo].[Branches] (
        BranchId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        BranchName VARCHAR(200) NOT NULL,
		[Location] VARCHAR(200) NOT NULL,
		ClientId VARCHAR(200) NOT NULL
    )
END