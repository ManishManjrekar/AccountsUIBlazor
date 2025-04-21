CREATE PROCEDURE [dbo].[GetAllCommissionPercentageData]
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [CommissionPercentage] WITH (NOLOCK) WHERE IsActive = 1;
END
