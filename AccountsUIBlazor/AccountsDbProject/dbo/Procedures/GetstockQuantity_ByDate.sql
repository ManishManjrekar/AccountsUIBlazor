CREATE PROCEDURE GetStockQuantity_ByDate
    @CreatedDate DATE
AS
BEGIN
    SELECT SUM(Quantity) AS TotalQuantity FROM [dbo].[StockIn] AS s WITH (NOLOCK) WHERE CONVERT(DATE, s.CreatedDate) = @CreatedDate AND isActive = 1;
END

