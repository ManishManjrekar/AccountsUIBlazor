CREATE PROCEDURE [dbo].[GetAllCommissionEarned]
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [CommissionEarned] WITH (NOLOCK) WHERE IsActive = 1;
END
