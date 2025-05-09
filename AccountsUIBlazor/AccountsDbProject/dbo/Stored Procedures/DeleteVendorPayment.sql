CREATE PROCEDURE [dbo].[DeleteVendorPayment]
@VendorPaymentId INT
AS
BEGIN
SET NOCOUNT ON;
    Update [VendorPayments] SET isActive=0  WHERE [VendorPaymentId] = @VendorPaymentId
END;            
           
           
    
           
           
          
           
          

           
           
           
           
           
           
          

           
    
          

