CREATE PROCEDURE [dbo].[DeleteCommissionEarned]
    @CommissionEarnedId INT
AS
BEGIN
    UPDATE [CommissionEarned] SET IsActive = 0 WHERE [CommissionEarnedId] = @CommissionEarnedId;
END
