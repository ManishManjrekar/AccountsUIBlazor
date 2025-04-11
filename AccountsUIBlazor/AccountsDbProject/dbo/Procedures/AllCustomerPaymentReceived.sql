CREATE PROCEDURE[dbo].[AllCustomerPaymentReceived]
AS
BEGIN 
    SELECT * FROM [CustomerPaymentReceived] (NOLOCK) WHERE IsActive = 1;
END;