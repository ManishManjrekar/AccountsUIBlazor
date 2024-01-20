using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class CustomerBalanceCarryForwardQueries
    {
		public static string AllCustomerBalanceCarryForward => "SELECT * FROM [accountancy].[dbo].[CustomerBalanceCarryForward] (NOLOCK)";
        public static string GetBalanceCarryForwardBy_CustomerId => "SELECT * FROM [accountancy].[dbo].[CustomerBalanceCarryForward] as c where c.CustomerId = @CustomerId and c.IsActive=1";

        public static string GetCustomerBalanceCarry_ByDate => @"SELECT * FROM [accountancy].[dbo].[CommissionAgentExpenses] as c
                                                  where CONVERT(DATE,c.CreatedDate) = @CreatedDate and isActive=1 ";

        public static string AddCustomerBalanceCarryForward =>
            @"INSERT INTO [dbo].[CustomerBalanceCarryForward]
           ([CustomerId]
            ,[CustomerName]
           ,[Amount]
           ,[CreatedDate]
           ,[ModifiedDate]
           ,[IsActive]
           ,[CreatedBy]
           ,[ModifiedBy]
           ,[LoggedInUser]
           ,[Comments]
           )
           
     VALUES
           (@CustomerId
            ,@CustomerName
           ,@Amount
           ,@CreatedDate
           ,@ModifiedDate
           ,@IsActive
           ,@CreatedBy
           ,@ModifiedBy
           ,@LoggedInUser
            ,@Comments
          )";

		public static string UpdateCustomerBalanceCarryForward =>
            @"UPDATE [CustomerPaymentReceived] 
            SET [CustomerId] = @CustomerId,
                [CustomerName] = @CustomerName, 
				[Amount] = @Amount, 
				[CreatedDate] = @CreatedDate, 
				[ModifiedDate] = @ModifiedDate
	            [IsActive] = @IsActive, 
				[CreatedBy] = @CreatedBy, 
				[ModifiedBy] = @ModifiedBy
                [LoggedInUser] = @LoggedInUser,
                [Comments] = @Comments
            WHERE [CustomerBalanceCarryForwardId] = @CustomerBalanceCarryForwardId";

      

        public static string DeleteCustomerBalanceCarryForward => "Update FROM [CustomerPaymentReceived] WHERE [CustomerBalanceCarryForwardId] = @CustomerBalanceCarryForwardId and isActive=0";
    }
}
