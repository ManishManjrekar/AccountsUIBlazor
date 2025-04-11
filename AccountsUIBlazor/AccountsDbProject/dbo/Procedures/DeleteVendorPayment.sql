CREATE PROCEDURE [dbo].[DeleteVendorPayment]
@VendorPaymentId INT
AS
BEGIN
    Update [VendorPayments] SET isActive=0  WHERE [VendorPaymentId] = @VendorPaymentId
END;            
           
           
    
           
           
          
           
          

           
           
           
           
           
           
          

           
    
          

