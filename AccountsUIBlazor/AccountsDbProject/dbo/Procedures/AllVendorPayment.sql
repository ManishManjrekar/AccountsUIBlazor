CREATE PROCEDURE [dbo].[AllVendorPayment]
AS
BEGIN
SELECT * FROM [VendorPayments] WITH (NOLOCK) where IsActive=1
END;