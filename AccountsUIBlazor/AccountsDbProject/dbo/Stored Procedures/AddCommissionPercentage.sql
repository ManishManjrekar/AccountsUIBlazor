CREATE PROCEDURE [dbo].[AddCommissionPercentage]
    @CommissionPercentage NVARCHAR(255),
    @IsActive BIT
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO [dbo].[CommissionPercentage]([CommissionPercentage], [IsActive]) VALUES (@CommissionPercentage, @IsActive);
END

