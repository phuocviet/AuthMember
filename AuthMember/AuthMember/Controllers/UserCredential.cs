using AuthMember.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace AuthMember.Controllers
{
    public class UserCredential
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public Guid Id { get; set; }
        public Member Member { get; set; }
    }
}
