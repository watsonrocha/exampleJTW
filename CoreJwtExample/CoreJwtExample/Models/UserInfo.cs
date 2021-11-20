using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreJwtExample.Models
{
    public class UserInfo
    {
        [Key]
        public Guid UserIndoId { get; set; }
        [Required]

        public string Fullname { get; set; }
        [Required]

        public string EmailId { get; set; }
        [Required]

        public string Username { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
