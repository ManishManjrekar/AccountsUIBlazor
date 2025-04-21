CREATE PROCEDURE [dbo].[GetSalesDataAsPerStockInId]
    @StockInId INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT s.SalesId,s.CreatedDate,s.Price, s.Quantity, s.TotalAmount,c.FirstName AS CustomerName,v.FirstName AS VendorName, si.LoadName FROM [dbo].[Sales] AS s
    INNER JOIN [dbo].[Customer] AS c ON s.CustomerId = c.CustomerId
    INNER JOIN [dbo].[Vendor] AS v ON v.VendorId = s.VendorId
    INNER JOIN [dbo].[StockIn] AS si ON s.StockInId = si.StockInId WHERE s.StockInId = @StockInId AND s.IsActive = 1;
END
