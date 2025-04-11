CREATE PROCEDURE [dbo].[DeleteVendor]
@VendorId INT 
AS
BEGIN
	Update [Vendor] SET  isActive=0 WHERE [VendorId] = @VendorId
END;
