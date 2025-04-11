CREATE PROCEDURE [dbo].[GetVendorPayments_ByDate]
@CreatedDate DATETIME
AS
BEGIN
   SELECT * FROM [dbo].[VendorPayments] as c where CONVERT(DATE,c.CreatedDate) = @CreatedDate and isActive=1
   END;  
