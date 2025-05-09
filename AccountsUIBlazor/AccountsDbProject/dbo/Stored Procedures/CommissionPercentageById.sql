CREATE PROCEDURE [dbo].[CommissionPercentageById]
    @CommissionPercentageId INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM [CommissionPercentage] WITH (NOLOCK) WHERE [CommissionPercentageId] = @CommissionPercentageId  AND IsActive = 1;
END
