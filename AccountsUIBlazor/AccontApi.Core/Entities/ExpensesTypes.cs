using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Core.Entities
{
    public class ExpensesTypes
    {
       // public ExpensesTypes() { }
        public int ExpensesId { get; set; }
        public string ExpensesType { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        //[Required]
        public string MiddleName { get; set; }

        //[Required]
        public string NickName { get; set; }

        //[Required]
        public string LastName { get; set; }

        //[Required]
        // public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        public string ReferredBy { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        //public string Url { get; set; }

        public bool IsActive { get; set; }

    }
}
