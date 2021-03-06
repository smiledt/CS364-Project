-- Create Database Statement
IF NOT EXISTS (
	SELECT name FROM master.dbo.sysdatabases
	WHERE name = N'Inventory'
	)

CREATE DATABASE Inventory 
GO

-- Database Use Statement
USE Inventory

-- Drop ALL tables if they already exist
DROP TABLE IF EXISTS History;
DROP TABLE IF EXISTS Item;
DROP TABLE IF EXISTS Warehouse;
DROP TABLE IF EXISTS Addresses;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Employee;

-- create Employee table
CREATE TABLE Employee (
    Employee_ID INT PRIMARY KEY NOT NULL,
    Cube INT NOT NULL,
    Department NVARCHAR(25),
    First_Name NVARCHAR(25) NOT NULL,
    Middle_Name NVARCHAR(25),
    Last_Name NVARCHAR(25) NOT NULL
);

-- create Addresses table prior to the Warehouse Table
CREATE TABLE Addresses (
	Address_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Street_Address NVARCHAR(100) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	State NVARCHAR(2) NOT NULL,
	Zip_Code INT NOT NULL
);


-- create history table
CREATE TABLE Warehouse (
    Warehouse_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Warehouse_Name NVARCHAR(25) NOT NULL,
    Address_ID INT NOT NULL,

	FOREIGN KEY(Address_ID) REFERENCES Addresses(Address_ID)
);

-- create Items table
CREATE TABLE Item (
    Asset_Tag INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Serial_Number NVARCHAR(10) NOT NULL,
    Model NVARCHAR(20) NOT NULL CHECK (Model IN (
	'Monitor', 'Laptop', 'Desktop', 'Docking Station', 'Printer', 'Phone')),
	Note NVARCHAR(255),
    Employee_ID INT,
    Warehouse_ID Int,
    
    FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID)
);

-- create History Table
CREATE TABLE History (
    Record INT PRIMARY KEY NOT NULL,
    Check_In SMALLDATETIME,
    Employee_ID INT,
    Asset_Tag INT,
    
    FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID),
    FOREIGN KEY (Asset_Tag) REFERENCES Item(Asset_Tag)
);

-- create User table
CREATE TABLE Users (
    User_ID INT PRIMARY KEY NOT NULL,
    Username NVARCHAR(20) NOT NULL,
    Pass NVARCHAR(20) NOT NULL
);

GO

--Begin Test Cases Here--
INSERT INTO Users (User_ID, Username, Pass)
	VALUES (00000, 'test', 'test')

INSERT INTO Employee (Employee_ID, Cube, First_Name, Middle_Name, Last_Name)
	VALUES (00000, 00000, 'test_first', 'test_middle', 'test_last')

INSERT INTO Employee (Employee_ID, Cube, Department, First_Name, Middle_Name, Last_Name)
	VALUES (00001, 00001, 'IT', 'Derek', 'Thomas', 'Smiley')

INSERT INTO Addresses (Street_Address, City, State, Zip_Code)
	VALUES ('1234 Main St', 'La Crosse', 'WI', 54601)

INSERT INTO Warehouse (Warehouse_Name, Address_ID)
  VALUES ('Test Warehouse', 1)

INSERT INTO Item (Serial_Number, Model, Note, Employee_ID)
	VALUES ('TESTS/N01', 'Laptop', 'This is test item 01', 00000)

INSERT INTO Item (Serial_Number, Model, Note, Warehouse_ID)
	VALUES ('TESTS/N02', 'Laptop', 'This is test item 02', 00001)

INSERT INTO Item (Serial_Number, Model, Note, Employee_ID, Warehouse_ID)
	VALUES ('TESTS/N03', 'Docking Station', 'This is test item 03', 00001, null)

	