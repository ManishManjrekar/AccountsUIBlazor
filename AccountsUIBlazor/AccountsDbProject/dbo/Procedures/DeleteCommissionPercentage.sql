CREATE PROCEDURE [dbo].[DeleteCommissionPercentage]
    @CommissionPercentageId INT
AS
BEGIN
    UPDATE [CommissionPercentage] SET IsActive = 0WHERE [CommissionPercentageId] = @CommissionPercentageId;
END

