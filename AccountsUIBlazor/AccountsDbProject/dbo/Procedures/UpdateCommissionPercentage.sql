CREATE PROCEDURE [dbo].[UpdateCommissionPercentage]
    @CommissionPercentageId INT,
    @CommissionPercentage NVARCHAR(255),
    @IsActive BIT
AS
BEGIN
    UPDATE [CommissionPercentage] SET [CommissionPercentage] = @CommissionPercentage,[IsActive] = @IsActive WHERE [CommissionPercentageId] = @CommissionPercentageId AND IsActive = 1;
END
