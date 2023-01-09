using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.User
{
    public class LoginDto
    {
        [Required, EmailAddress]
        [DataType(DataType.Password)]

        public string Email { get; set; }
        [Required, StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
