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
	ArtistId int FOREIGN KEY REFERENCES Artists(ArtistId),
	RecordLabelId int FOREIGN KEY REFERENCES RecordLabels(RecordLabelId),
);

CREATE TABLE Inventory (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    AlbumId int FOREIGN KEY REFERENCES Albums(AlbumId),
	Stock int NOT NULL
);