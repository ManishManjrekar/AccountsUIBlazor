CREATE PROCEDURE [dbo].[VendorPaymentById]
@VendorPaymentId INT
AS
BEGIN
  SELECT * FROM [VendorPayments] (NOLOCK) WHERE [VendorPaymentId] = @VendorPaymentId and IsActive=1
END;