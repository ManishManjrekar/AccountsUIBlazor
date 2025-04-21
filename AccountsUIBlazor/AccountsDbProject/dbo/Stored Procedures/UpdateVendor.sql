CREATE PROCEDURE [dbo].[UpdateVendor]
@VendorId  INT,
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@Mobile NVARCHAR(50),
@ElectronicPaymentId NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [Vendor] SET [FirstName] = @FirstName, [LastName] = @LastName, [ElectronicPaymentId] = @ElectronicPaymentId, [Mobile] = @Mobile
    WHERE [VendorId] = @VendorId and IsActive =1;
END;