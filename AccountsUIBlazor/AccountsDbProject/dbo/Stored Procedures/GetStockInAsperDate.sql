CREATE PROCEDURE [dbo].[GetStockInAsperDate]
    @CreatedDate DATE
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [dbo].[StockIn] AS s WITH (NOLOCK) WHERE CONVERT(DATE, s.CreatedDate) = @CreatedDate  AND s.isActive = 1;
END

