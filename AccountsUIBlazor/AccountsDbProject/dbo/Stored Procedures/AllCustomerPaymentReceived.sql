CREATE PROCEDURE[dbo].[AllCustomerPaymentReceived]
AS
BEGIN 
SET NOCOUNT ON;
    SELECT * FROM [CustomerPaymentReceived] (NOLOCK) WHERE IsActive = 1;
END;