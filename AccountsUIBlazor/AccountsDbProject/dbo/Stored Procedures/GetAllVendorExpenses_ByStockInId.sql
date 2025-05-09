CREATE PROCEDURE [dbo].[GetAllVendorExpenses_ByStockInId]
@StockInId INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [VendorExpenses] (NOLOCK) WHERE [StockInId] = @StockInId AND IsActive=1;
END