--CREATE PROCEDURE [dbo].[GetCustomerBalanceCarry_ByDate]
--    @CreatedDate DATE
--AS
--BEGIN
--    SELECT * 
--    FROM [dbo].[CommissionAgentExpenses] AS c
--    WHERE CONVERT(DATE, c.CreatedDate) = @CreatedDate 
--    AND IsActive = 1;
--END;

CREATE PROCEDURE [dbo].[GetCustomerBalanceCarry_ByDate]
    @CreatedDate DATE
AS
BEGIN
    SELECT * 
    FROM [dbo].[CustomerBalanceCarryForward] AS c WHERE CONVERT(DATE, c.CreatedDate) = @CreatedDate AND IsActive = 1;
END;