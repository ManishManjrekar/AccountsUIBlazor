using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class VendorPaymentQueries
	{
        public static string AllVendorPayment => "SELECT * FROM [VendorPayment] (NOLOCK)";

        public static string CustomerPaymentById => "SELECT * FROM [VendorPayment] (NOLOCK) WHERE [VendorId] = @VendorId";

        public static string AddCustomerPayment =>
            @"INSERT INTO [dbo].[VendorPayment]
           ([CustomerName]
           ,[AmountPaid]
           ,[CreatedDate]
           ,[ModifiedDate]
           ,[IsActive]
           ,[CreatedBy]
           ,[ModifiedBy]
           ,[LoggedInUser]
           ,[TypeOfTransaction]
           ,[Comments]
)
           
     VALUES
           (@CustomerName
           ,@AmountPaid
           ,@CreatedDate
           ,@ModifiedDate
           ,@IsActive
           ,@CreatedBy
           ,@ModifiedBy
           ,@LoggedInUser
           ,@TypeOfTransaction
            @Comments
          )";

        public static string UpdateCustomer =>
            @"UPDATE [VendorPayment] 
            SET [CustomerName] = @CustomerName, 
				[AmountPaid] = @AmountPaid, 
				[CreatedDate] = @CreatedDate, 
				[ModifiedDate] = @ModifiedDate
	            [IsActive] = @IsActive, 
				[CreatedBy] = @CreatedBy, 
				[ModifiedBy] = @ModifiedBy
                [LoggedInUser] = @LoggedInUser,
                [TypeOfTransaction] = @TypeOfTransaction
                [Comments] = @Comments,
            WHERE [CustomerPaymentId] = @CustomerPaymentId";

        public static string DeleteCustomer => "Update FROM [VendorPayment] WHERE [CustomerPaymentId] = @CustomerPaymentId where isActive=0";
    }
}
