USE master
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DVDLibrary
GO
 
CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO


GRANT EXECUTE ON CreateDvd TO DvdLibraryApp
GRANT EXECUTE ON DeleteDvd TO DvdLibraryApp
GRANT EXECUTE ON GetAllDvds TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByDirector TO DvdLibraryApp
GRANT EXECUTE ON GetDvdById TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByRating TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByYear TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByTitle TO DvdLibraryApp
GRANT EXECUTE ON UpdateDvd TO DvdLibraryApp
GO


GRANT SELECT ON Dvd TO DvdLibraryApp
GRANT INSERT ON Dvd TO DvdLibraryApp
GRANT UPDATE ON Dvd TO DvdLibraryApp
GRANT DELETE ON Dvd TO DvdLibraryApp

GRANT SELECT ON Rating TO DvdLibraryApp
GRANT INSERT ON Rating TO DvdLibraryApp
GRANT UPDATE ON Rating TO DvdLibraryApp
GRANT DELETE ON Rating TO DvdLibraryApp
GO