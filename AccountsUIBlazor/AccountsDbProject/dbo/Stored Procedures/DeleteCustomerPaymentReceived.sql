CREATE PROCEDURE [dbo].[DeleteCustomerPaymentReceived]
    @CustomerPaymentId INT
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [dbo].[CustomerPaymentReceived] SET [IsActive] = 0 WHERE [CustomerPaymentId] = @CustomerPaymentId;
END;

