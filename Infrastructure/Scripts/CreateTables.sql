DROP TABLE Inventory;
DROP TABLE Albums;
DROP TABLE Artists;
DROP TABLE RecordLabels;

CREATE TABLE Artists (
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name varchar(MAX) NOT NULL
);


CREATE TABLE RecordLabels (
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name varchar(MAX) NOT NULL
);

CREATE TABLE Albums (
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name varchar(MAX) NOT NULL,
	AlbumType int NOT NULL,
	ArtistId int FOREIGN KEY REFERENCES Artists(Id),
	RecordLabelId int FOREIGN KEY REFERENCES RecordLabels(Id),
);

CREATE TABLE Inventory (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    AlbumId int FOREIGN KEY REFERENCES Albums(Id),
	Stock int NOT NULL
);