CREATE PROCEDURE  [dbo].[GetCommissionAgentExpensesByStockInId] 
@StockInId INT=0 
AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM dbo.[CommissionAgentExpenses] WITH (NOLOCK) WHERE StockInId = @StockInId AND IsActive = 1;
END;
