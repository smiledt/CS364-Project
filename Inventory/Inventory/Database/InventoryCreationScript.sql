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
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Employee;

-- create Employee table
CREATE TABLE Employee (
    Employee_ID INT PRIMARY KEY NOT NULL,
    Cube INT NOT NULL,
    Department NVARCHAR(25) NOT NULL,
    First_Name NVARCHAR(25) NOT NULL,
    Middle_Name NVARCHAR(25),
    Last_Name NVARCHAR(25) NOT NULL
);

-- create history table
CREATE TABLE Warehouse (
    Warehouse_ID INT PRIMARY KEY NOT NULL,
    Warehouse_Name NVARCHAR(25) NOT NULL,
    Adress NVARCHAR(25) NOT NULL
);

-- create Items table
CREATE TABLE Item (
    Asset_Tag INT PRIMARY KEY NOT NULL,
    Service_Tag NVARCHAR(10) NOT NULL,
    Model NVARCHAR(20) NOT NULL,
    Employee_ID INT,
    Warehouse_ID Int,
    
    FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID),
    FOREIGN KEY (Warehouse_ID) REFERENCES Warehouse(Warehouse_ID)
);

-- drop History table if it already exists
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
    Email NVARCHAR(30) NOT NULL,
    Username NVARCHAR(20) NOT NULL,
    Pass NVARCHAR(20) NOT NULL
)
