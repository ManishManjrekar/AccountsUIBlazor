using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AccountAPIGateway.UIModels
{


    public class UICustomerNames
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }


    [DataContract]
    public class UICustomer
    {
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        //////[Required]
        //[AllowNull]
        //[JsonIgnore]
        //public string Email { get; set; }

        //[AllowNull]
        [IgnoreDataMember]
        public string ElectronicPaymentId { get; set; }


        [Required]
        public string Mobile { get; set; }

        // [AllowNull]
        [IgnoreDataMember]
        public string ReferredBy { get; set; }


       


    }
}
