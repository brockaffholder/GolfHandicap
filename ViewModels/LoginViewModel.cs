using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicap.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Must provide a username to login")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Must provide a password to login")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

    }
}
