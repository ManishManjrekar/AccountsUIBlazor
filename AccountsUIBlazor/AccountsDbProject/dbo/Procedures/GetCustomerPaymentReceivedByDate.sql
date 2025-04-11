
CREATE PROCEDURE [dbo].[GetCustomerPaymentReceivedByDate]
    @PaymentDate DATETIME
AS
BEGIN
    SELECT  c.FirstName AS CustomerName,c.CustomerId,cp.AmountPaid,cp.ModifiedDate,cp.CreatedBy,cp.ModifiedBy,cp.LoggedInUser,  
     cp.PaymentDate,cp.TypeOfTransaction FROM [dbo].[CustomerPaymentReceived] AS cp   
     INNER JOIN [dbo].[Customer] AS c  ON cp.CustomerId = c.CustomerId 
     WHERE CONVERT(DATETIME, cp.PaymentDate) = @PaymentDate AND cp.IsActive = 1;
END;
         
        
       
        
        
        
   
    