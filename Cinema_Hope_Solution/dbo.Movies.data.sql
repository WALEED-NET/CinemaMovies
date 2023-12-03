--SET IDENTITY_INSERT [dbo].[Movies] ON
--INSERT INTO [dbo].[Movies] ([MovieId], [Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId]) VALUES (13, N'jon titer', NULL, 234, N'444ab9ae-0936-48e4-8021-b11261848fd0.jpg', NULL, 0, N'arabic', N'we', N'we', N'we', N'0001-01-01 00:00:00', NULL, 1)
--INSERT INTO [dbo].[Movies] ([MovieId], [Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId]) VALUES (14, N'spider man', N'jy', 656, N'985f2bcb-eadd-4cd5-8a69-8982e5777b1f.jpeg', NULL, 0, N'sds', N'sgfc', NULL, NULL, N'0001-01-01 00:00:00', NULL, 2)
--SET IDENTITY_INSERT [dbo].[Movies] OFF

--INSERT INTO	[dbo].[Movies] ( [Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
--VALUES							( N'The Godfather', N'An organized crime dynastys aging patriarch transfers control of his clandestine empire to his reluctant son.', 175, N'03.jpg', NULL, 9.2, N'English', N'Francis Ford Coppola', N'Mario Puzo, Francis Ford Coppola', N'Paramount Pictures', N'1972-03-24 00:00:00', NULL, 1);




---- Movie 1
--INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
--VALUES (N'The Godfather', N'An organized crime dynasty''s aging patriarch transfers control of his clandestine empire to his reluctant son.', 175, N'01.jpg', NULL, 9.2, N'English', N'Francis Ford Coppola', N'Mario Puzo, Francis Ford Coppola', N'Paramount Pictures', N'1972-03-24 00:00:00', NULL, 1);

---- Movie 2
--INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
--VALUES (N'Inception', N'A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.', 148, N'02.jpg', NULL, 8.8, N'English', N'Christopher Nolan', N'Christopher Nolan', N'Warner Bros.', N'2010-07-16 00:00:00', NULL, 2);

---- Movie 3
--INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
--VALUES (N'Pulp Fiction', N'The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.', 154, N'03.jpg', NULL, 8.9, N'English', N'Quentin Tarantino', N'Quentin Tarantino', N'Miramax Films', N'1994-10-14 00:00:00', NULL, 3);





-- Movie 4
INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
VALUES (N'The Shawshank Redemption', N'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.', 142, N'04.jpg', NULL, 9.3, N'English', N'Frank Darabont', N'Stephen King (short story "Rita Hayworth and Shawshank Redemption"), Frank Darabont (screenplay)', N'Columbia Pictures', N'1994-09-23 00:00:00', NULL, 4);

-- Movie 5
INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
VALUES (N'Fight Club', N'An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.', 139, N'05.jpg', NULL, 8.8, N'English', N'David Fincher', N'Chuck Palahniuk (novel), Jim Uhls (screenplay)', N'20th Century Fox', N'1999-10-15 00:00:00', NULL, 5);

-- Movie 6
INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
VALUES (N'The Dark Knight', N'When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.', 152, N'f1.jpg', NULL, 9.0, N'English', N'Christopher Nolan', N'Jonathan Nolan (screenplay), Christopher Nolan (screenplay)', N'Warner Bros.', N'2008-07-18 00:00:00', NULL, 5);



-- Movie 1
INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
VALUES (N'The Godfather', N'An organized crime dynasty''s aging patriarch transfers control of his clandestine empire to his reluctant son.', 175, N'01.jpg', NULL, 9.2, N'English', N'Francis Ford Coppola', N'Mario Puzo, Francis Ford Coppola', N'Paramount Pictures', N'1972-03-24 00:00:00', NULL, 1);

-- Movie 2
INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
VALUES (N'Inception', N'A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.', 148, N'02.jpg', NULL, 8.8, N'English', N'Christopher Nolan', N'Christopher Nolan', N'Warner Bros.', N'2010-07-16 00:00:00', NULL, 2);

-- Movie 3
INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
VALUES (N'Pulp Fiction', N'The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.', 154, N'03.jpg', NULL, 8.9, N'English', N'Quentin Tarantino', N'Quentin Tarantino', N'Miramax Films', N'1994-10-14 00:00:00', NULL, 3);

-- Movie 4
INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
VALUES (N'The Shawshank Redemption', N'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.', 142, N'04.jpg', NULL, 9.3, N'English', N'Frank Darabont', N'Stephen King (short story "Rita Hayworth and Shawshank Redemption"), Frank Darabont (screenplay)', N'Columbia Pictures', N'1994-09-23 00:00:00', NULL, 4);

-- Movie 5
INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
VALUES (N'Fight Club', N'An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.', 139, N'05.jpg', NULL, 8.8, N'English', N'David Fincher', N'Chuck Palahniuk (novel), Jim Uhls (screenplay)', N'20th Century Fox', N'1999-10-15 00:00:00', NULL, 5);

-- Movie 6
INSERT INTO [dbo].[Movies] ([Title], [Description], [Duration], [PosterUrl], [TrailerUrl], [Rating], [Language], [Director], [Writers], [ProductionCompany], [ReleaseDate], [Status], [GenreId])
VALUES (N'The Dark Knight', N'When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.', 152, N'f1.jpg', NULL, 9.0, N'English', N'Christopher Nolan', N'Jonathan Nolan (screenplay), Christopher Nolan (screenplay)', N'Warner Bros.', N'2008-07-18 00:00:00', NULL, 5);
