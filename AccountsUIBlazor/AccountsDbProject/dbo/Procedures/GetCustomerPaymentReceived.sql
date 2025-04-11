CREATE PROCEDURE [dbo].[GetCustomerPaymentReceived]
    @CustomerId INT
AS
BEGIN
    SELECT c.FirstName AS CustomerName,c.CustomerId,cp.AmountPaid,cp.ModifiedDate,cp.CreatedBy,cp.ModifiedBy,cp.LoggedInUser
    FROM [dbo].[CustomerPaymentReceived] AS cp  
    INNER JOIN [dbo].[Customer] AS c ON cp.CustomerId = c.CustomerId WHERE cp.CustomerId = @CustomerId 
      AND cp.IsActive = 1;
END;    
      
