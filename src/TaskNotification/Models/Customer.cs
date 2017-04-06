using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskNotification.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Company { get; set; }
        public string ContactName { get; set; }
        //[Required]
        //[Phone(ErrorMessage = "Must be 10 numbers")]
        //[Display(Name = "Reply Text")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
