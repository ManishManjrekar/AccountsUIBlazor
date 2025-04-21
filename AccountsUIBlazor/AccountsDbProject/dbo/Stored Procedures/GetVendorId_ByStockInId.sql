CREATE PROCEDURE[dbo].[GetVendorId_ByStockInId]
    @StockInId INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT VendorId FROM [StockIn] WITH (NOLOCK) WHERE [StockInId] = @StockInId AND isActive = 1;
END
