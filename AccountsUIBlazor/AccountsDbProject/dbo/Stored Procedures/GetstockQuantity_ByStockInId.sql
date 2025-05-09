CREATE PROCEDURE GetStockQuantity_ByStockInId
    @StockInId INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT Quantity FROM [StockIn] WITH (NOLOCK) WHERE [StockInId] = @StockInId AND isActive = 1;
END
