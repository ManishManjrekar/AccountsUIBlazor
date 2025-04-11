CREATE PROCEDURE [dbo].[GetSales_Sum_Between_Dates]
    @FromDate DATE,
    @ToDate DATE
AS
BEGIN
    SELECT SUM(s.TotalAmount) AS TotalSalesAmount FROM [dbo].[Sales] AS s WHERE CONVERT(DATE, s.CreatedDate) BETWEEN @FromDate AND @ToDate AND s.IsActive = 1;
END
