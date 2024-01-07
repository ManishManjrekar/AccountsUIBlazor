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
		public static string AllCustomerBalanceCarryForward => "SELECT * FROM [CustomerBalanceCarryForward] (NOLOCK)";
        public static string GetBalanceCarryForwardBy_CustomerId => "SELECT * FROM [CustomerBalanceCarryForward] as c where c.CustomerId = @CustomerId and cp.IsActive=1";
        

		public static string AddCustomerBalanceCarryForward =>
            @"INSERT INTO [dbo].[CustomerBalanceCarryForward]
           ([CustomerId]
            ,[CustomerName]
           ,[AmountPaid]
           ,[PaymentDate]
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
           ,@AmountPaid
           ,@PaymentDate
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
				[AmountPaid] = @AmountPaid, 
				[PaymentDate] = @PaymentDate, 
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
