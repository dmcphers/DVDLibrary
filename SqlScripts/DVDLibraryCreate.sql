USE master
GO
 
IF EXISTS(SELECT * FROM sys.databases WHERE Name='DVDLibrary')
DROP DATABASE DVDLibrary
GO
 
CREATE DATABASE DVDLibrary
GO

USE DvdLibrary
GO

/* drop tables if they exist */

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvd')
   DROP TABLE Dvd
GO
 
IF EXISTS(SELECT * FROM sys.tables WHERE name='Rating')
   DROP TABLE Rating
GO

/* create tables */

CREATE TABLE Rating (
	RatingId int identity(1,1) primary key not null,
	RatingName varchar(5) not null
)
 
CREATE TABLE Dvd (
	DvdId int identity(1,1) primary key not null,
	Title varchar(50) not null,
	ReleaseYear int null,
	DirectorName varchar(50) null,
	RatingId int foreign key references Rating(RatingId) null,
	Notes varchar(250) null
 )



