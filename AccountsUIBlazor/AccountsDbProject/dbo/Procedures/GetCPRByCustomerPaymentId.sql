
CREATE PROCEDURE [dbo].[GetCPRByCustomerPaymentId]
AS
BEGIN 
    SELECT * FROM [CustomerPaymentReceived] where CustomerPaymentId =1
END;