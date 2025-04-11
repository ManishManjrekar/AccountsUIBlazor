CREATE PROCEDURE [dbo].[GetCommissionPercentage_Active]
AS
BEGIN
    SELECT CommissionPercentage FROM [CommissionPercentage] WITH (NOLOCK) WHERE IsActive = 1;
END
