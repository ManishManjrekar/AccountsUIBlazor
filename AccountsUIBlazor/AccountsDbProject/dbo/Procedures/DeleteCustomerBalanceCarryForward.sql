CREATE PROCEDURE [dbo].[DeleteCustomerBalanceCarryForward]
    @CustomerBalanceCarryForwardId INT
AS
BEGIN
	UPDATE [dbo].[CustomerBalanceCarryForward] 
    SET IsActive = 0
    WHERE CustomerBalanceCarryForwardId = @CustomerBalanceCarryForwardId;
END;

