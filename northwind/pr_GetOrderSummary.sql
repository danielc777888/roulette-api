USE Northwind
GO

CREATE OR ALTER PROCEDURE dbo.pr_GetOrderSummary  @StartDate datetime, @EndDate datetime, @EmployeeID int = NULL, @CustomerID nchar(5) = NULL
AS

WITH OrdersCte AS (
SELECT
	CAST(o.OrderDate AS date) AS 'Date',
	o.EmployeeID,
	o.CustomerID,
	o.ShipVia,
	SUM (o.Freight) as 'TotalFreightCost'
FROM Orders o
GROUP BY CAST(o.OrderDate AS date),
	o.EmployeeID,
	o.CustomerID,
	o.ShipVia
),

OrderDetailsCte AS (
SELECT
	CAST(o.OrderDate AS date) AS 'Date',
	o.EmployeeID,
	o.CustomerID,
	o.ShipVia,
	COUNT(DISTINCT o.OrderID) AS 'NumberOfOrders',
	SUM ((od.Quantity * od.UnitPrice) - od.Discount) as 'TotalOrderValue',
	COUNT(DISTINCT od.ProductID) AS 'NumberOfDifferentProducts'
FROM Orders o
INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY CAST(o.OrderDate AS date),
	o.EmployeeID,
	o.CustomerID,
	o.ShipVia)

SELECT CONCAT(e.TitleOfCourtesy, e.FirstName, e.LastName) AS 'EmployeeFullName',
	s.CompanyName AS 'Shipper CompanyName',
	c.CompanyName AS 'Customer CompanyName',
	od.NumberOfOrders,
	o.Date,
	o.TotalFreightCost,
	od.NumberOfDifferentProducts,
	od.TotalOrderValue
FROM OrdersCte o
INNER JOIN Employees e ON e.EmployeeID = o.EmployeeID
INNER JOIN Customers c ON c.CustomerID = o.CustomerID
INNER JOIN Shippers s ON s.ShipperID = o.ShipVia
INNER JOIN OrderDetailsCte od ON od.Date = o.Date AND od.EmployeeID = o.EmployeeID AND od.CustomerID = o.CustomerID AND od.ShipVia = o.ShipVia
WHERE o.Date BETWEEN @StartDate AND @EndDate
	AND (@EmployeeID IS NULL OR o.EmployeeID = @EmployeeID)
	AND (@CustomerID IS NULL OR o.CustomerID = @CustomerID)

GO



exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID=NULL

exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID=NULL

exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID='VINET'

exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID='VINET'

