USE DVDLibrary

SET IDENTITY_INSERT Rating ON
 
INSERT INTO Rating (RatingId, RatingName)
VALUES (1, 'G'),
	(2, 'PG'),
	(3, 'PG-13'),
	(4, 'R')
 
SET IDENTITY_INSERT Rating OFF


SET IDENTITY_INSERT Dvd ON
 
INSERT INTO Dvd (DvdId, Title, ReleaseYear, DirectorName, RatingId, Notes)
VALUES (1, 'Beauty and the Beast', 1991, 'Kirk Wise', 1 ,
            'A prince cursed to spend his days as a hideous monster sets 
			out to regain his humanity by earning a young womans love.'),
	(2, 'Home Alone', 1990, 'Chris Columbus', 2 , 
	     'An eight-year-old troublemaker must protect his house from a pair of 
		 burglars when he is accidentally left home alone by his family during
		 Christmas vacation.'),
	(3, 'The Dark Knight', 2008, 'Christopher Nolan', 3 ,
	     'When the menace known as the Joker wreaks havoc and chaos on the people of
		 Gotham, Batman must accept one of the greatest psychological and physical tests
		 of his ability to fight injustice.'),
	(4, 'The Game', 1997, 'David Fincher', 4 ,
	     'After a wealthy San Francisco banker is given an opportunity to participate 
		 in a mysterious game, his life is turned upside down as he begins to question 
		 if it might really be a concealed conspiracy to destroy him.'),
    (5, 'Rocky', 1976, 'Sylvester Stallone', 2 , 
	     'The rags to riches American Dream story of Rocky Balboa, an uneducated,
		 kind-hearted working class Italian-American boxer, working as a debt collector
		 for a loan shark in the slums of Philadelphia. Rocky, a small-time club fighter,
		 gets a shot at the world heavyweight championship.')
 
SET IDENTITY_INSERT Dvd OFF

