CREATE PROCEDURE [dbo].[UpdateCommissionEarned]
    @CommissionEarnedId INT,
    @VendorId INT,
    @StockInId BIGINT,
    @CommissionPercentage DECIMAL(18, 2),
    @LoadName NVARCHAR(255),
    @VendorName NVARCHAR(255),
    @Amount DECIMAL(18, 2),
    @CreatedDate DATETIME,
    @ModifiedDate DATETIME,
    @LoggedInUser NVARCHAR(255),
    @Comments NVARCHAR(MAX),
    @IsActive BIT
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [CommissionEarned]
    SET [VendorId] = @VendorId, [StockInId] = @StockInId,[CommissionPercentage] = @CommissionPercentage,[LoadName] = @LoadName,[VendorName] = @VendorName,
        [Amount] = @Amount, [CreatedDate] = @CreatedDate, [ModifiedDate] = @ModifiedDate,[LoggedInUser] = @LoggedInUser,[Comments] = @Comments,[IsActive] = @IsActive
        WHERE [CommissionEarnedId] = @CommissionEarnedId 
        AND IsActive = 1;
END
