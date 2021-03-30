CREATE TABLE Brands(
Id int PRIMARY KEY IDENTITY(1,1),
Name varchar(25) NOT NULL
)

CREATE TABLE Colors(
Id int PRIMARY KEY IDENTITY(1,1),
Name varchar(25) NOT NULL
)


CREATE TABLE Cars(
Id int PRIMARY KEY IDENTITY(1,1),
BrandId int NOT NULL FOREIGN KEY REFERENCES Brands(Id),
ColorId int NOT NULL FOREIGN KEY REFERENCES Colors(Id),
ModelYear int NOT NULL,
DailyPrice decimal NOT NULL,
Description varchar(250)
)

CREATE TABLE CarImages(
Id int PRIMARY KEY IDENTITY(1,1),
CarId int NOT NULL FOREIGN KEY REFERENCES Cars(Id),
ImagePath varchar(250) NOT NULL,
Date date
)

CREATE TABLE Users(
Id int PRIMARY KEY IDENTITY(1,1),
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
Email varchar(100) NOT NULL,
Password varchar(100) NOT NULL
)

CREATE TABLE Customers(
Id int PRIMARY KEY IDENTITY(1,1),
UserId int NOT NULL FOREIGN KEY REFERENCES Users(Id),
CompanyName varchar(100)
)

CREATE TABLE Rentals(
Id int PRIMARY KEY IDENTITY (1,1),
CarId int NOT NULL FOREIGN KEY REFERENCES Cars(Id),
CustomerId int NOT NULL FOREIGN KEY REFERENCES Customers(Id),
RentDate date,
ReturnDate date
)