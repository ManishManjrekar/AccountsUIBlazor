CREATE PROCEDURE [dbo].[GetSales_Sum_Per_Date]
    @CreatedDate DATE
AS
BEGIN
    SELECT SUM(s.TotalAmount) AS TotalSalesAmount FROM [dbo].[Sales] AS s WHERE CONVERT(DATE, s.CreatedDate) = @CreatedDate AND s.IsActive = 1;
END
