CREATE PROCEDURE [dbo].[GetStockInAsPerVendorId]
    @VendorId INT,
    @fromDate DATETIME,
    @toDate DATETIME
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [dbo].[StockIn] AS s WITH (NOLOCK) WHERE s.VendorId = @VendorId AND s.CreatedDate BETWEEN @fromDate AND @toDate;
END

