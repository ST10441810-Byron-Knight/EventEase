-- Database creation section
use master
	IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EventEaseDB')
	DROP DATABASE EventEaseDB
	CREATE DATABASE EventEaseDB
	use EventEaseDB

-- Table creation section
CREATE TABLE Venue (
VenueID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
VenueName VARCHAR(50) UNIQUE NOT NULL,
[Location] VARCHAR(150) NOT NULL,
Capacity INT NOT NULL,
ImageURL VARCHAR(MAX) NOT NULL
);

CREATE TABLE [Event] (
EventID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
EventName VARCHAR(50) UNIQUE NOT NULL,
EventDate VARCHAR(150) NOT NULL,
[Description] VARCHAR(150) NOT NULL
);

CREATE TABLE Booking (
BookingID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
EventID INT FOREIGN KEY REFERENCES Event (EventID),
VenueID INT FOREIGN KEY REFERENCES Venue (VenueID),
BookingDate VARCHAR(150) NOT NULL
);

-- Table insertion section
INSERT INTO Venue (VenueName, [Location], Capacity, ImageURL)
VALUES ('Example venue name', 'Example location', '30', 'Placeholder URL')

INSERT INTO [Event] (EventName, EventDate, [Description])
VALUES ('Example event name', 'DD-MM-YYYY', 'Example description')

INSERT INTO Booking (EventID, VenueID, BookingDate)
VALUES ('1', '1', 'DD-MM-YYYY')

-- Table alteration section

-- Table manipulation section
SELECT * FROM Venue
SELECT * FROM [Event]
SELECT * FROM Booking

-- Stored procedures