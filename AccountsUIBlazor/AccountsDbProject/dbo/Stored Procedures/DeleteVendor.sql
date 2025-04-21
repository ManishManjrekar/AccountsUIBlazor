CREATE PROCEDURE [dbo].[DeleteVendor]
@VendorId INT 
AS
BEGIN
SET NOCOUNT ON;
	Update [Vendor] SET  isActive=0 WHERE [VendorId] = @VendorId
END;
