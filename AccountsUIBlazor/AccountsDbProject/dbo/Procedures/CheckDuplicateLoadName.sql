CREATE PROCEDURE [dbo].[CheckDuplicateLoadName]
    @VendorId INT,
    @createdDate DATE,
    @LoadName NVARCHAR(100)
AS
BEGIN
    SELECT COUNT(s.StockInId) AS DuplicateCount FROM [dbo].[StockIn] AS s WITH (NOLOCK) WHERE s.VendorId = @VendorId 
      AND CONVERT(DATE, s.CreatedDate) = @createdDate AND s.LoadName = @LoadName;
END

