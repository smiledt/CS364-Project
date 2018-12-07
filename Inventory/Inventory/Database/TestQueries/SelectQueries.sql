USE Inventory

SELECT *
	FROM Users

SELECT *
	FROM Item


SELECT *
	FROM Addresses

SELECT *
	FROM Warehouse

SELECT * 
	FROM Employee

SELECT *
	FROM Warehouse INNER JOIN Addresses ON Warehouse.Address_ID = Addresses.Address_ID