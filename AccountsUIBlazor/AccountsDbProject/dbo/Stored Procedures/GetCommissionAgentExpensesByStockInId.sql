CREATE PROCEDURE [dbo].[GetAllCommissionAgentExpenses_ByStockInId]
    @StockInId INT
AS
BEGIN
SET NOCOUNT ON;
		SELECT * FROM [dbo].CommissionAgentExpenses [CommissionAgentExpenses] WITH (NOLOCK) WHERE [StockInId] = @StockInId AND IsActive = 1;
END;



--CREATE PROCEDURE [dbo].[GetCommissionAgentExpensesByStockInId]
--    @StockInId INT
--AS
--BEGIN
--SET NOCOUNT ON;
--		SELECT * FROM [CommissionAgentExpenses] WITH (NOLOCK) WHERE [StockInId] = @StockInId AND IsActive = 1;
--END;
