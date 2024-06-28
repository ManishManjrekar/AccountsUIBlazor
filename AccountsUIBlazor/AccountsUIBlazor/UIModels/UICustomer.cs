//using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace AccountsUIBlazor.UIModels
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


        [IgnoreDataMember]
        //[IgnoreDataMember, Input(Ignore = true)]
        public string ElectronicPaymentId { get; set; }


        [Required]
        public string Mobile { get; set; }


        [IgnoreDataMember]
        public string ReferredBy { get; set; }




    }
}
