CREATE PROCEDURE [dbo].[StockInById]
    @StockInId INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [StockIn] WITH (NOLOCK) WHERE [StockInId] = @StockInId;
END

