CREATE PROCEDURE [dbo].[DeleteCustomerBalanceCarryForward]
    @CustomerBalanceCarryForwardId INT
AS
BEGIN
SET NOCOUNT ON;
	UPDATE [dbo].[CustomerBalanceCarryForward] SET IsActive = 0 WHERE CustomerBalanceCarryForwardId = @CustomerBalanceCarryForwardId;
END;

