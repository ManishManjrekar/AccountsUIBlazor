CREATE PROCEDURE [dbo].[GetActiveCommissionAgentExpenses]
@IsActive Bit
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [dbo].[CommissionAgentExpenses] WITH (NOLOCK) WHERE IsActive = 1;
END;

