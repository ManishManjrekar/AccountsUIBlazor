using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class VendorExpensesQueries
    {
        public static string GetAllVendorExpenses => "SELECT * FROM [VendorExpenses] (NOLOCK) where IsActive=1";

        public static string GetAllVendorExpenses_ByStockInId => "SELECT * FROM [VendorExpenses] (NOLOCK) WHERE [StockInId] = @StockInId and IsActive=1";

        public static string GetVendorExpenses_ByDate => @"SELECT * FROM [accountancy].[dbo].[VendorExpenses] as c
                                                  where CONVERT(DATE,c.CreatedDate) = @CreatedDate and isActive=1 ";
        public static string AddVendorExpenses =>
            @"INSERT INTO [dbo].[VendorExpenses]
           ( [VendorId]
            ,[StockInId]
            ,[ExpensesName]
            ,[VendorName]
            ,[LoadName]
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
             ,@VendorName
            ,@LoadName
           ,@AmountPaid
           ,@CreatedDate
           ,@ModifiedDate
           ,@LoggedInUser
           , @Comments
           ,@IsActive
          )";

        public static string UpdateVendorExpenses =>
            @"UPDATE [VendorExpenses] 
            SET [VendorId] = @VendorId, 
				[StockInId] = @StockInId,
                [ExpensesName] = @ExpensesName
                [VendorName] = @VendorName
				[LoadName] = @LoadName, 
				[AmountPaid] = @AmountPaid, 
				[CreatedDate] = @CreatedDate, 
				[ModifiedDate] = @ModifiedDate,
                [LoggedInUser] = @LoggedInUser,
                [Comments] = @Comments,
	            [IsActive] = @IsActive, 
            WHERE [VendorExpensesId] = @VendorExpensesId and IsActive=1 ";

       
        public static string DeleteVendorExpenses => "Update [VendorExpenses] set isActive=0 where [VendorExpensesId] = @VendorExpensesId ";
    }
}
