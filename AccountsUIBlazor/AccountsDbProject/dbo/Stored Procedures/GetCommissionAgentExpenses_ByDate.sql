CREATE PROCEDURE [dbo].[GetCommissionAgentExpensesByCreatedDate]
    @CreatedDate DATE
AS
BEGIN
SET NOCOUNT ON;
   SELECT * FROM [dbo].[CommissionAgentExpenses] AS c WITH (NOLOCK) WHERE CONVERT(DATE, c.CreatedDate) = @CreatedDate AND IsActive = 1;
END;