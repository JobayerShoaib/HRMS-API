using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identities.Accounts.Commands.DTM
{
    public class SignUpDTM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]       
        public string ConfirmPassword { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string UserType { get; set; }
    }
}
