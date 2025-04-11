CREATE PROCEDURE [dbo].[DeleteStockIn]
    @StockInId INT
AS
BEGIN
    UPDATE [StockIn] SET isActive = 0 WHERE [StockInId] = @StockInId AND isActive = 1;
END

