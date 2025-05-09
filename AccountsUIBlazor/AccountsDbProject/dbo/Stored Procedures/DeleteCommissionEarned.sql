CREATE PROCEDURE [dbo].[DeleteCommissionEarned]
    @CommissionEarnedId INT
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [CommissionEarned] SET IsActive = 0 WHERE [CommissionEarnedId] = @CommissionEarnedId;
END
