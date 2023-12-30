using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Sql.Queries
{
	[ExcludeFromCodeCoverage]
	public static class VendorQueries
    {
		public static string AllVendor => "SELECT * FROM [Vendor] (NOLOCK)";

		public static string VendorById => "SELECT * FROM [Vendor] (NOLOCK) WHERE [CustomerId] = @CustomerId";

		public static string AddVendor =>
            @"INSERT INTO [dbo].[Vendor]
           ([FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[MobileNo]
           ,[ModifiedDate]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[ModifiedBy]
           ,[IsActive]
           ,[ElectronicPaymentId]
           ,[ReferredBy]
           ,[Address]
            ,[City]
            ,[State]
           )
     VALUES
           (@FirstName
           ,@MiddleName
           ,@LastName
           ,@MobileNo
           ,@ModifiedDate
           ,@CreatedDate
           ,@CreatedBy
           ,@ModifiedBy
           ,@IsActive
           ,@ElectronicPaymentId
           ,@ReferredBy
           ,@Address
             ,@City
             ,@State
           )";

		public static string UpdateVendor =>
            @"UPDATE [Vendor] 
            SET [FirstName] = @FirstName, 
				[LastName] = @LastName, 
				[ElectronicPaymentId] = @ElectronicPaymentId, 
				[PhoneNumber] = @PhoneNumber
            WHERE [CustomerId] = @CustomerId";

		public static string DeleteVendor => "Update FROM [Vendor] WHERE [VendorId] = @CustomerId where isActive=0";
	}
}
