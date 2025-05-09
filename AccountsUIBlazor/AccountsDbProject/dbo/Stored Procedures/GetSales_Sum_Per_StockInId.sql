CREATE PROCEDURE [dbo].[GetSales_Sum_Per_StockInId]
    @StockInId INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT  SUM(s.TotalAmount) AS TotalSalesAmount FROM [dbo].[Sales] AS s WHERE s.StockInId = @StockInId AND s.IsActive = 1;
END
