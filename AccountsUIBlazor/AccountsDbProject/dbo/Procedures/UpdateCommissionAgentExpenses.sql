﻿--CREATE PROCEDURE [dbo].[UpdateCommissionAgentExpense]
--    @CommissionAgentExpensesId INT,
--    @VendorId INT,
--    @StockInId INT,
--    @ExpensesName NVARCHAR(100),
--    @ElectronicPaymentId INT,
--    @AmountPaid DECIMAL(18,2),
--    @CreatedDate DATETIME,
--    @ModifiedDate DATETIME,
--    @LoggedInUser NVARCHAR(100),
--    @Comments NVARCHAR(MAX),
--    @IsActive BIT
--AS
--BEGIN
--     UPDATE [CommissionAgentExpenses]SET[VendorId] = @VendorId,[StockInId] = @StockInId,[ExpensesName] = @ExpensesName,[ElectronicPaymentId] = @ElectronicPaymentId,
--        [AmountPaid] = @AmountPaid,[CreatedDate] = @CreatedDate,[ModifiedDate] = @ModifiedDate,[LoggedInUser] = @LoggedInUser,
--        [Comments] = @Comments,[IsActive] = @IsActive WHERE [CommissionAgentExpensesId] = @CommissionAgentExpensesId AND IsActive = 1;
--END;

