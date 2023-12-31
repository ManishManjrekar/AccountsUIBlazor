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
		public static string AllVendor => "SELECT * FROM [Vendor] (NOLOCK) where IsActive =1 ";

		public static string VendorById => "SELECT * FROM [Vendor] (NOLOCK) WHERE [VendorId] = @VendorId";

		public static string AddVendor =>
            @"INSERT INTO [dbo].[Vendor]
           ([FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Mobile]
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
           ,@Mobile
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
				[Mobile] = @Mobile
            WHERE [CustomerId] = @VendorId and IsActive =1";

		public static string DeleteVendor => "Update [Vendor] set  isActive=0 where [VendorId] = @VendorId";
	}
}
