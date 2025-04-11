CREATE PROCEDURE [dbo].[StockInById]
    @StockInId INT
AS
BEGIN
    SELECT * FROM [StockIn] WITH (NOLOCK) WHERE [StockInId] = @StockInId;
END

