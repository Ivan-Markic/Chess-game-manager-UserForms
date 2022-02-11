--Chess initialize scripte

CREATE TABLE Person
(
	IDPerson int primary key identity,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	Age int not null,
	Email nvarchar(30) not null,
	Picture varbinary(max) null
)
GO

create table ChessGame(
	IDChessGame int  primary key identity not null,
	FirstPlayerID int foreign key references Person(IDPerson) not null,
	SecondPlayerID int foreign key references Person(IDPerson) not null,
	GameLocation nvarchar(200) not null
)
GO

--Done
CREATE PROC GetPeople
AS
SELECT * FROM Person
GO

CREATE PROC GetPerson
	@idPerson int
AS
SELECT * FROM Person WHERE IDPerson = @idPerson
GO

--Done
CREATE PROC DeletePerson
	@idPerson int
AS
DELETE FROM ChessGame WHERE FirstPlayerID = @idPerson
DELETE FROM ChessGame WHERE SecondPlayerID = @idPerson
DELETE FROM Person WHERE IDPerson = @idPerson
GO

--Done
CREATE PROC AddPerson
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@idPerson INT OUTPUT
AS 
BEGIN
INSERT INTO Person VALUES (@firstname, @lastname, @age, @email, @picture)
	SET @idPerson = SCOPE_IDENTITY()
END
GO

--Done
CREATE PROC UpdatePerson
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@idPerson int
AS
UPDATE Person SET 
		FirstName = @firstname,
		LastName = @lastname,
		Age = @age,
		Email = @email,
		Picture = @picture
	WHERE 
		IDPerson = @idPerson

GO

--Done
CREATE PROC GetChessGames
AS
SELECT * FROM ChessGame
GO

--Done
CREATE PROC GetChessGame
	@idChessGame int
AS
SELECT * FROM ChessGame WHERE IDChessGame = @idChessGame
GO

--Done
CREATE PROC DeleteChessGame
	@idChessGame int
AS
DELETE FROM ChessGame WHERE IDChessGame = @idChessGame
GO

--Done
CREATE PROC AddChessGame
	@idPersonP1 INT,
	@idPersonP2 INT,
	@gamelocation nvarchar(200),
	@idChessGame INT OUTPUT
AS 
BEGIN
INSERT INTO ChessGame VALUES (@idPersonP1, @idPersonP2, @gamelocation)
	SET @idChessGame = SCOPE_IDENTITY()
END
GO

--Done
CREATE PROC UpdateChessGame
	@gamelocation nvarchar(200),
	@idChessGame int
AS
UPDATE ChessGame SET 
		GameLocation = @gamelocation
	WHERE 
		IDChessGame = @idChessGame



