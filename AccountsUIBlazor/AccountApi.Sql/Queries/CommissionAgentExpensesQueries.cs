using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class CommissionAgentExpensesQueries
    {
        public static string GetAllCommissionAgentExpenses => "SELECT * FROM [CommissionAgentExpenses] (NOLOCK) where IsActive=1";

        public static string GetAllCommissionAgentExpenses_ByStockInId => "SELECT * FROM [CommissionAgentExpenses] (NOLOCK) WHERE [StockInId] = @StockInId and IsActive=1";

        public static string GetCommissionAgentExpenses_ByDate => @"SELECT * FROM [accountancy].[dbo].[CommissionAgentExpenses] as c
                                                         where CONVERT(DATE,c.CreatedDate) = @CreatedDate and isActive=1 ";

        public static string AddCommissionAgentExpenses =>
            @"INSERT INTO [dbo].[CommissionAgentExpenses]
           ( [VendorId]
            ,[StockInId]
            ,[ExpensesName]
            ,[ElectronicPaymentId]
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
            ,@ElectronicPaymentId
           ,@AmountPaid
           ,@CreatedDate
           ,@ModifiedDate
           ,@LoggedInUser
           , @Comments
           ,@IsActive
          )";

        public static string UpdateCommissionAgentExpenses =>
            @"UPDATE [CommissionAgentExpenses] 
            SET [VendorId] = @VendorId, 
				[StockInId] = @StockInId,
                [ExpensesName] = @ExpensesName
                [ElectronicPaymentId] = @ElectronicPaymentId
				[AmountPaid] = @AmountPaid, 
				[CreatedDate] = @CreatedDate, 
				[ModifiedDate] = @ModifiedDate,
                [LoggedInUser] = @LoggedInUser,
                [Comments] = @Comments,
	            [IsActive] = @IsActive, 
            WHERE [CommissionAgentExpensesId] = @CommissionAgentExpensesId and IsActive=1 ";

       
        public static string DeleteCommissionAgentExpenses => "Update [CommissionAgentExpenses] set isActive=0 where [CommissionAgentExpensesId] = @CommissionAgentExpensesId ";
    }
}
