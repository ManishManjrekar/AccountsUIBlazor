CREATE PROCEDURE [dbo].[GetStockInAsPerDates]
    @fromDate DATETIME,
    @toDate DATETIME
AS
BEGIN
    SELECT * FROM [dbo].[StockIn] AS s WITH (NOLOCK) WHERE s.CreatedDate BETWEEN @fromDate AND @toDate;
END

