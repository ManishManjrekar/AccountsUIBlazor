using System.ComponentModel.DataAnnotations;

namespace AccountApi.Core
{
    public class Vendor
    {
        public int VendorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        //[Required]
        public string MiddleName { get; set; }
        //public string NickName { get; set; }

        public string LastName { get; set; }

        public string MobileNo { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        public string ReferredBy { get; set; }
        public string ElectronicPaymentId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}