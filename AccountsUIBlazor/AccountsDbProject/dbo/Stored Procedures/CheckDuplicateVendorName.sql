          
 CREATE PROCEDURE [dbo].[CheckDuplicateVendorName]
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100)
AS
BEGIN 
SET NOCOUNT ON;
    SELECT COUNT(v.VendorId) AS VendorCount FROM [dbo].[Vendor] AS v
    WHERE v.FirstName = @FirstName AND v.LastName = @LastName AND v.IsActive = 1;
END;
