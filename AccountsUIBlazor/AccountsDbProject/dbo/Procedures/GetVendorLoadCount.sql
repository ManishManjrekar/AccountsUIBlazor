CREATE PROCEDURE [dbo].[GetVendorLoadCount]
    @VendorId INT,
    @createdDate DATE
AS
BEGIN
    SELECT COUNT(s.StockInId) AS LoadCount FROM [dbo].[StockIn] AS s WITH (NOLOCK)WHERE s.VendorId = @VendorId AND CONVERT(DATE, s.CreatedDate) = @createdDate;
END

