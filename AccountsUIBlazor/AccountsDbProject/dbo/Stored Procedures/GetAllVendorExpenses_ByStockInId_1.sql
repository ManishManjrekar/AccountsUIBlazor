CREATE PROCEDURE [dbo].[GetVendorExpensesByStockInId]
@StockInId INT
AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM [VendorExpenses] WITH (NOLOCK) WHERE [StockInId] = @StockInId AND IsActive = 1;
END