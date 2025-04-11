CREATE PROCEDURE[dbo].[GetStockInWhereIn_PaymentNotCompleted]
AS
BEGIN
    SELECT * FROM [dbo].[StockIn] AS s WITH (NOLOCK) WHERE s.IsPaymentDone = 0 AND s.isActive = 1;
END
