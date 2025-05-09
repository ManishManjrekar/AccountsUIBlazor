CREATE PROCEDURE [dbo].[AddCommissionEarned]
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
    INSERT INTO [dbo].[CommissionEarned]
        ([VendorId], [StockInId], [CommissionPercentage], [LoadName], [VendorName], [Amount], [CreatedDate], [ModifiedDate], [LoggedInUser], [Comments], [IsActive])
    VALUES
        (@VendorId, @StockInId, @CommissionPercentage, @LoadName, @VendorName, @Amount, @CreatedDate, @ModifiedDate, @LoggedInUser, @Comments, @IsActive);
END
