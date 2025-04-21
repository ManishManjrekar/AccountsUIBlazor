CREATE PROCEDURE [dbo].[DeleteCommissionPercentage]
    @CommissionPercentageId INT
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [CommissionPercentage] SET IsActive = 0WHERE [CommissionPercentageId] = @CommissionPercentageId;
END

