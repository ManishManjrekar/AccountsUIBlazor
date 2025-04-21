CREATE PROCEDURE [dbo].[AllVendorPayment]
AS
BEGIN
SET NOCOUNT ON;
SELECT * FROM [VendorPayments] WITH (NOLOCK) where IsActive=1
END;