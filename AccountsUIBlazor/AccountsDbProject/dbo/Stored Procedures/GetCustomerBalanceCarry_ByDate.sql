CREATE PROCEDURE [dbo].[GetCustomerBalanceCarry_ByDate]
    @CreatedDate DATE
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [dbo].[CommissionAgentExpenses] AS c
 WHERE CONVERT(DATE, c.CreatedDate) = @CreatedDate 
    AND IsActive = 1;
END;
