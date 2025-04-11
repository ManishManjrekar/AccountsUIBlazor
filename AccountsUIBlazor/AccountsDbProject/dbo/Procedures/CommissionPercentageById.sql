CREATE PROCEDURE [dbo].[CommissionPercentageById]
    @CommissionPercentageId INT
AS
BEGIN
    SELECT * 
    FROM [CommissionPercentage] WITH (NOLOCK) WHERE [CommissionPercentageId] = @CommissionPercentageId  AND IsActive = 1;
END
