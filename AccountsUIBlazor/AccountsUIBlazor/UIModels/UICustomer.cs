using System.ComponentModel.DataAnnotations;

namespace AccountsUIBlazor.UIModels
{


    public class UICustomerNames
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }


    public class UICustomer
    {
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        ////[Required]
        public string MiddleName { get; set; }

        ////[Required]
       // public string Email { get; set; }

        public string ElectronicPaymentId { get; set; }


        [Required]
        public string Mobile { get; set; }

        public string ReferredBy { get; set; }


        //// Not to be filled by user form data , its only used for back data 
        //public string CreatedBy { get; set; }

        //public string ModifiedBy { get; set; }

        //public DateTime ModifiedDate { get; set; }

        //public DateTime CreatedDate { get; set; }

        //public bool IsActive { get; set; }


    }
}
