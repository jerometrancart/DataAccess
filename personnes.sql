USE master
GO
IF NOT EXISTS (
    SELECT name 
    FROM sys.databases 
    WHERE name = N'ApprendreCsharp'
)
CREATE DATABASE [ApprendreCsharp]
GO
CREATE TABLE [Personnes]
(
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL , 
    Nom NVARCHAR(256),
    Prenom NVARCHAR(256)
)
GO