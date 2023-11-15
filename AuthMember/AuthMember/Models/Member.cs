using AuthMember.Controllers;
using System;
using System.ComponentModel.DataAnnotations;

namespace AuthMember.Models
{
    public class Member
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        public UserCredential UserCredential { get; set; }
    }
}
