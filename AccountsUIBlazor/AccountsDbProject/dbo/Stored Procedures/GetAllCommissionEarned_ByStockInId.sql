CREATE PROCEDURE [dbo].[GetAllCommissionEarned_ByStockInId]
    @StockInId BIGINT
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [CommissionEarned] WITH (NOLOCK) WHERE [StockInId] = @StockInId AND IsActive = 1;
END
