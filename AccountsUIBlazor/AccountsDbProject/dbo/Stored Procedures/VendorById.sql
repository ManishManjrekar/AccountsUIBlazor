CREATE PROCEDURE [dbo].[VendorById]
@VendorId INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [Vendor] (NOLOCK) WHERE [VendorId] = @VendorId and IsActive =1
END;