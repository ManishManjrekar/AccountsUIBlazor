CREATE PROCEDURE [dbo].[GetCommission_for_Sales_PercentageValue]
    @StockInId INT,
    @PercentageCommission DECIMAL
AS
BEGIN
    SELECT 
        SUM(s.TotalAmount) * @PercentageCommission / 100.0 AS CommissionValue FROM [dbo].[Sales] AS s WHERE s.StockInId = @StockInId  AND s.IsActive = 1;
END
