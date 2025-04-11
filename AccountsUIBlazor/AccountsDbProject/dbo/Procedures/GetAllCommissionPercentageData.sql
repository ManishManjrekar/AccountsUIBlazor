CREATE PROCEDURE [dbo].[GetAllCommissionPercentageData]
AS
BEGIN
    SELECT * FROM [CommissionPercentage] WITH (NOLOCK) WHERE IsActive = 1;
END
