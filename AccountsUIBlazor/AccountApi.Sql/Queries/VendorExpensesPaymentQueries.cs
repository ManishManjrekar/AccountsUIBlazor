using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class VendorExpensesPaymentQueries
    {
        public static string GetAllVendorExpensesPayment => "SELECT * FROM [VendorExpensesPayment] (NOLOCK) where IsActive=1";

        public static string GetAllVendorExpensesPayment_ByStockInId => "SELECT * FROM [VendorExpensesPayment] (NOLOCK) WHERE [StockInId] = @StockInId and IsActive=1";

        public static string AddVendorExpensesPayment =>
            @"INSERT INTO [dbo].[VendorExpensesPayment]
           ( [VendorId]
            ,[StockInId]
            ,[ExpensesName]
           ,[AmountPaid]
           ,[CreatedDate]
           ,[ModifiedDate]
           ,[LoggedInUser]
           ,[Comments]
           ,[IsActive]
)
           
     VALUES
           (@VendorId
            ,@StockInId
            ,@ExpensesName
           ,@AmountPaid
           ,@CreatedDate
           ,@ModifiedDate
           ,@LoggedInUser
           , @Comments
           ,@IsActive
          )";

        public static string UpdateVendorExpensesPayment =>
            @"UPDATE [VendorExpensesPayment] 
            SET [VendorId] = @VendorId, 
				[StockInId] = @StockInId,
                [ExpensesName] = @ExpensesName
				[AmountPaid] = @AmountPaid, 
				[CreatedDate] = @CreatedDate, 
				[ModifiedDate] = @ModifiedDate,
                [LoggedInUser] = @LoggedInUser,
                [Comments] = @Comments,
	            [IsActive] = @IsActive, 
            WHERE [VendorExpensesPaymentId] = @VendorExpensesPaymentId and IsActive=1 ";

       
        public static string DeleteVendorExpensesPayment => "Update [VendorExpensesPayment] set isActive=0 where [VendorExpensesPaymentId] = @VendorExpensesPaymentId ";
    }
}
