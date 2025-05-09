
CREATE PROCEDURE [dbo].[GetCPRByCustomerPaymentId]
AS
BEGIN 
SET NOCOUNT ON;
    SELECT * FROM [CustomerPaymentReceived] where CustomerPaymentId =1
END;