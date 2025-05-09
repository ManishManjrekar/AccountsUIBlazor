CREATE PROCEDURE [dbo].[GetCommissionPercentage_Active]
AS
BEGIN
SET NOCOUNT ON;
    SELECT CommissionPercentage FROM [CommissionPercentage] WITH (NOLOCK) WHERE IsActive = 1;
END
