using System.ComponentModel.DataAnnotations;

namespace AccountAPIGateway.UIModels
{
    public class UIVendor
    {
        public int VendorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        //[Required]
        public string MiddleName { get; set; }

        //[Required]
       // public string NickName { get; set; }

        //[Required]
        public string LastName { get; set; }

        //[Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        public string ReferredBy { get; set; }

        public string ElectronicPaymentId { get; set; }

        //public string CreatedBy { get; set; }

        //public string ModifiedBy { get; set; }

        //public DateTime ModifiedDate { get; set; }

        //public DateTime CreatedDate { get; set; }

        //public string Url { get; set; }

        //public bool IsActive { get; set; }
    }
}