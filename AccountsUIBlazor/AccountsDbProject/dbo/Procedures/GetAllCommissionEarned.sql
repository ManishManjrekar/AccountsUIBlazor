CREATE PROCEDURE [dbo].[GetAllCommissionEarned]
AS
BEGIN
    SELECT * FROM [CommissionEarned] WITH (NOLOCK) WHERE IsActive = 1;
END
