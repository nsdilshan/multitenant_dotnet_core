IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'SystemDb')
BEGIN

	CREATE DATABASE [SystemDb]

END
GO
    USE [SystemDb]
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Clients' and xtype='U')
BEGIN
    CREATE TABLE [dbo].[Clients] (
        ClientId NVARCHAR(100) NOT NULL PRIMARY KEY,
        ClientName VARCHAR(200) NOT NULL,
		DbServer VARCHAR(200) NOT NULL,
		DbName VARCHAR(200) NOT NULL,
		ConnectionString VARCHAR(200) NOT NULL
    )
END

USE [SystemDb]
GO

INSERT INTO [dbo].[Clients] ([ClientId],[ClientName],[DbServer],[DbName],[ConnectionString])
     VALUES ('client001','Client 01','mssqllocaldb','ClientDb',''),
			('client002','Client 02','mssqllocaldb','ClientDb02','')
GO