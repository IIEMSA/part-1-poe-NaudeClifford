USE master
IF EXISTS	(SELECT * FROM sys.databases WHERE name = 'POEDatabase')
DROP DATABASE POEDatabase
CREATE DATABASE POEDatabase

USE POEDatabase

--TABLE CREATION
CREATE TABLE Event1(

Event_ID int,
Event_Name VARCHAR(250) NOT NULL,
Event_Date Date NOT NULL,
Description1 VARCHAR(250) NOT NULL,
Venue_Id int NOT NULL,
PRIMARY KEY(Event_Id),
FOREIGN KEY (Venue_Id) REFERENCES Event1(Event_Id)
);

CREATE TABLE Venue1(

Venue_Id int,
Venue_Name VARCHAR(250) NOT NULL,
Location1 VARCHAR(250) NOT NULL,
Capacity int NOT NULL,
ImageURL VARCHAR(250),
PRIMARY KEY(Venue_Id),
);

CREATE TABLE Bookings1(

Booking_Id int,
Event_Id int,
Venue_Id int,
Booking_Date DATE NOT NULL,
PRIMARY KEY(Booking_Id),
FOREIGN KEY (Event_Id) REFERENCES Event1(Event_Id),
FOREIGN KEY (Venue_Id) REFERENCES Venue1(Venue_Id)
);