using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskNotification.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName( "Your email is your username")]
        public string UserName { get; set; }

        [Required]
       
        public string Password { get; set; }
    }
}
