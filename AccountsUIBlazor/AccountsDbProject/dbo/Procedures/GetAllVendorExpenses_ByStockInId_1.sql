CREATE PROCEDURE [dbo].[GetVendorExpensesByStockInId]
@StockInId INT
AS
BEGIN
SELECT * FROM [VendorExpenses] WITH (NOLOCK) WHERE [StockInId] = @StockInId AND IsActive = 1;
END