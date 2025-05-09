CREATE PROCEDURE [dbo].[DeleteCommissionAgentExpenses]
   @CommissionAgentExpensesId INT
AS
BEGIN
SET NOCOUNT ON;
		Update [CommissionAgentExpenses] set isActive=0 where [CommissionAgentExpensesId] = @CommissionAgentExpensesId
END;