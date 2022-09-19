use DVDLibrary
go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdById')
	DROP PROCEDURE GetDvdById
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllDvds')
		DROP PROCEDURE GetAllDvds
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsByDirector')
		DROP PROCEDURE GetDvdsByDirector
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsByTitle')
		DROP PROCEDURE GetDvdsByTitle
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsByYear')
		DROP PROCEDURE GetDvdsByYear
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDvdsByRating')
		DROP PROCEDURE GetDvdsByRating
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateDvd')
		DROP PROCEDURE CreateDvd
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateDvd')
		DROP PROCEDURE UpdateDvd
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteDvd')
		DROP PROCEDURE DeleteDvd
GO

---------------------------GetDvdById---------------------------
CREATE PROCEDURE GetDvdById (
@DvdId int
) AS

	SELECT DvdId, Title, ReleaseYear, DirectorName, RatingId, Notes
	FROM Dvd
	WHERE DvdId = @DvdId

GO

---------------------------GetAllDvds---------------------------
CREATE PROCEDURE GetAllDvds AS

	SELECT DvdId, Title, ReleaseYear, DirectorName, RatingId, Notes
	FROM Dvd
	ORDER BY DvdId

GO

---------------------------GetDvdsByDirector---------------------------
CREATE PROCEDURE GetDvdsByDirector(
@DirectorName varchar(50)
) 
AS

	Select DvdId, Title, ReleaseYear, DirectorName, RatingId, Notes
	From Dvd
	Where DirectorName = @DirectorName
	Order By DirectorName

GO

---------------------------GetDvdsByTitle---------------------------
CREATE PROCEDURE GetDvdsByTitle(
@Title varchar(50)
)
AS

	Select DvdId, Title, ReleaseYear, DirectorName, RatingId, Notes
	From Dvd
	Where Title = @Title
	Order By Title

GO

---------------------------GetDvdsByYear---------------------------
CREATE PROCEDURE GetDvdsByYear(
@ReleaseYear char(4)
)
AS

	Select DvdId, Title, ReleaseYear, DirectorName, RatingId, Notes
	From Dvd
	Where ReleaseYear = @ReleaseYear
	Order By ReleaseYear

GO

---------------------------GetDvdsByRating---------------------------
CREATE PROCEDURE GetDvdsByRating(
@RatingId char(5)
)
AS

	SELECT DvdId, Title, ReleaseYear, DirectorName, RatingId, Notes
	FROM Dvd
	WHERE RatingId = @RatingId
	ORDER BY RatingId

GO

---------------------------CreateDvd---------------------------
CREATE PROCEDURE CreateDvd(
@DvdId int output,
@Title varchar(50),
@ReleaseYear char(4),
@DirectorName varchar(50),
@RatingId char(5),
@Notes varchar(250)
)
AS

	INSERT INTO Dvd(Title,ReleaseYear,DirectorName,RatingId,Notes)
	VALUES(@Title, @ReleaseYear, @DirectorName, @RatingId, @Notes)
SET @DvdId = SCOPE_IDENTITY();

GO

---------------------------UpdateDvd---------------------------
CREATE PROCEDURE UpdateDvd (
@DvdId int,
@Title varchar(50),
@ReleaseYear char(4),
@DirectorName varchar(50),
@RatingId varchar(5),
@Notes varchar(250)
)
AS

	UPDATE Dvd SET
	Title = @Title,
	ReleaseYear = @ReleaseYear,
	DirectorName = @DirectorName,
	RatingId = @RatingId,
	Notes = @Notes
	
	WHERE DvdId = @DvdId

GO

---------------------------DeleteDvd---------------------------
CREATE PROCEDURE DeleteDvd (
@DvdId int
) AS

	DELETE FROM Dvd
	WHERE DvdId = @DvdId;

GO