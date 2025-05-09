CREATE PROCEDURE [dbo].[UpdateCommissionPercentage]
    @CommissionPercentageId INT,
    @CommissionPercentage NVARCHAR(255),
    @IsActive BIT
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [CommissionPercentage] SET [CommissionPercentage] = @CommissionPercentage,[IsActive] = @IsActive WHERE [CommissionPercentageId] = @CommissionPercentageId AND IsActive = 1;
END
