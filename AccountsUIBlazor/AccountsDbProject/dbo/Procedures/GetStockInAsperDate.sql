CREATE PROCEDURE [dbo].[GetStockInAsperDate]
    @CreatedDate DATE
AS
BEGIN
    SELECT * FROM [dbo].[StockIn] AS s WITH (NOLOCK) WHERE CONVERT(DATE, s.CreatedDate) = @CreatedDate  AND s.isActive = 1;
END

