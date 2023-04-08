using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.User
{
    public class ChangePasswordDto
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required, Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}