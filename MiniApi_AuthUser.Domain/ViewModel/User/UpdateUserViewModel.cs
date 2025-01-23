using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApi_AuthUser.Domain.ViewModel.User
{ 
    public class UpdateUserViewModel
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }

        public string? FullName { get; set; }

        public int? Age { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(500)]
        public string Password { get; set; }
    }

    public enum UpdateUserResult
    {
        Success,
        NotFound,
        EmailInvalid
    }
}
