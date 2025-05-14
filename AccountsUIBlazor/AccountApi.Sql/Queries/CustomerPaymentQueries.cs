using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class CustomerPaymentQueries
    {
		public static string AllCustomerPaymentReceived => "SELECT * FROM [CustomerPaymentReceived] (NOLOCK)";
        public static string GetCPRByCustomerPaymentId => "SELECT * FROM [CustomerPaymentReceived] where CustomerPaymentId =@CustomerPaymentId";
        public static string GetCustomerPaymentReceivedByCustomerId => @"SELECT c.FirstName as CustomerName, c.CustomerId,
            cp.AmountPaid, cp.ModifiedDate, cp.CreatedBy, cp.ModifiedBy, cp.LoggedInUser
            FROM [accountancy].[dbo].[CustomerPaymentReceived] as cp  inner join 
            [accountancy].[dbo].[Customer] as c on cp.CustomerId = c.CustomerId WHERE cp.CustomerId = @CustomerId and cp.IsActive=1";

		public static string AddCustomerPayment =>
            @"INSERT INTO [dbo].[CustomerPaymentReceived]
           ([CustomerId]
            ,[CustomerName]
           ,[TypeOfTransaction]
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
           ,@TypeOfTransaction
           ,@AmountPaid
           ,@PaymentDate
           ,@ModifiedDate
           ,@IsActive
           ,@CreatedBy
           ,@ModifiedBy
           ,@LoggedInUser
            ,@Comments
          )";

		public static string UpdateCustomerPayment =>
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
                [TypeOfTransaction] = @TypeOfTransaction,
                [Comments] = @Comments
            WHERE [CustomerPaymentId] = @CustomerPaymentId";

        public static string GetCustomerPaymentReceivedByDate => @"SELECT c.FirstName as CustomerName, c.CustomerId,
            cp.AmountPaid, cp.ModifiedDate, cp.CreatedBy, cp.ModifiedBy, cp.LoggedInUser,cp.PaymentDate,cp.TypeOfTransaction
            FROM [accountancy].[dbo].[CustomerPaymentReceived] as cp  inner join 
            [accountancy].[dbo].[Customer] as c on cp.CustomerId = c.CustomerId 
            where CONVERT(DATE,cp.PaymentDate) = @PaymentDate and cp.IsActive=1";

        public static string DeleteCustomerPaymentReceived => "Update FROM [CustomerPaymentReceived] WHERE [CustomerPaymentId] = @CustomerPaymentId and isActive=0";

        // Added
        public static string GetAllCustomerPaymentByDates => @"
            SELECT c.FirstName AS CustomerName, c.CustomerId,
                   cp.AmountPaid, cp.ModifiedDate, cp.PaymentDate, cp.ModifiedBy, cp.LoggedInUser, cp.Comments
            FROM [accountancy].[dbo].[CustomerPaymentReceived] AS cp
            INNER JOIN [accountancy].[dbo].[Customer] AS c ON cp.CustomerId = c.CustomerId
            WHERE cp.CustomerId = @CustomerId
              AND cp.IsActive = 1
              AND cp.PaymentDate BETWEEN @fromDate AND @toDate";

    }
}
