
CREATE PROCEDURE [dbo].[GetAllCommissionAgentExpenses]
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [CommissionAgentExpenses] WITH (NOLOCK)WHERE IsActive = 1;
END



	