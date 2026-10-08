--CREATE DATABASE MoviesDb;
--GO

--USE MoviesDb;
--GO

--CREATE TABLE Genre
--(
--	Id INT PRIMARY KEY IDENTITY(1,1),
--	GenreName NVARCHAR(50) NOT NULL
--);

--INSERT INTO Genre (GenreName)
--VALUES ('Action'), ('Drama'), ('Science Fiction'),
--       ('Documentary'), ('Fantasy'), ('Comedy');

--CREATE TABLE Movies
--(
--    Id INT PRIMARY KEY IDENTITY(1,1),
--    Title NVARCHAR(100) NOT NULL,
--    ReleaseYear INT NOT NULL,
--    GenreId INT NOT NULL,
--    CONSTRAINT FK_Movies_Genre
--        FOREIGN KEY (GenreId) REFERENCES Genre(Id)
--);

--INSERT INTO Movies (Title, ReleaseYear, GenreId) 
--VALUES
--	-- Action (1)
--	('Die Hard', 1988, 1),
--	('The Dark Knight', 2008, 1),
--	('Mad Max: Fury Road', 2015, 1),

--	-- Drama (2)
--	('Schindler''s List', 1993, 2),
--	('The Shawshank Redemption', 1994, 2),
--	('Forrest Gump', 1994, 2),

--	-- Science Fiction (3)
--	('Alien', 1979, 3),
--	('The Matrix', 1999, 3),
--	('Interstellar', 2014, 3),

--	-- Documentary (4)
--	('Bowling for Columbine', 2002, 4),
--	('March of the Penguins', 2005, 4),
--	('Free Solo', 2018, 4),

--	-- Fantasy (5)
--	('The Lord of the Rings: The Fellowship of the Ring', 2001, 5),
--	('Harry Potter and the Philosopher''s Stone', 2001, 5),
--	('Pan''s Labyrinth', 2006, 5),

--	-- Comedy (6)
--    ('Groundhog Day', 1993, 6),
--    ('Superbad', 2007, 6),
--    ('The Grand Budapest Hotel', 2014, 6);
