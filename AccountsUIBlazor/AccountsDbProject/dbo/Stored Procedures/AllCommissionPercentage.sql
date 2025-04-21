CREATE PROCEDURE [dbo].[AllCommissionPercentage]
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [CommissionPercentage] WITH (NOLOCK) WHERE IsActive = 1;
END
