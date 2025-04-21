CREATE PROCEDURE [dbo].[UpdateSales]
    @SalesId INT,
    @VendorId INT,
    @StockInId INT,
    @CustomerId INT,
    @Quantity INT,
    @Price DECIMAL(18, 2),
    @TotalAmount DECIMAL(18, 2),
    @Type NVARCHAR(50),
    @CreatedDate DATETIME,
    @ModifiedDate DATETIME,
    @CreatedBy NVARCHAR(50),
    @IsActive BIT,
    @LoggedInUser NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;
    UPDATE [Sales]SET [VendorId] = @VendorId, [StockInId] = @StockInId, [CustomerId] = @CustomerId,[Quantity] = @Quantity,[Price] = @Price, 
                      [TotalAmount] = @TotalAmount, [Type] = @Type,[CreatedDate] = @CreatedDate,[ModifiedDate] = @ModifiedDate,  
                       [CreatedBy] = @CreatedBy, [IsActive] = @IsActive,[LoggedInUser] = @LoggedInUser  WHERE [SalesId] = @SalesId AND  isActive = 1;
                       
END
       
        
        
       
       
        
        
       
      
   
        
