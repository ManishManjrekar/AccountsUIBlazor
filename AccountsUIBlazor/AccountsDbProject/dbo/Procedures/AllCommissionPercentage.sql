CREATE PROCEDURE [dbo].[AllCommissionPercentage]
AS
BEGIN
    SELECT * FROM [CommissionPercentage] WITH (NOLOCK) WHERE IsActive = 1;
END
