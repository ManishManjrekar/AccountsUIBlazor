CREATE PROCEDURE GetStockQuantity_ByStockInId
    @StockInId INT
AS
BEGIN
    SELECT Quantity FROM [StockIn] WITH (NOLOCK) WHERE [StockInId] = @StockInId AND isActive = 1;
END
