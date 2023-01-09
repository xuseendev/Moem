using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.User
{
    public class ApiUserDto : LoginDto
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Required, StringLength(15, ErrorMessage = "Your ConfirmPassword is limited to {2} to {1} characters", MinimumLength = 6)]


        public string ConfirmPassword { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int UserGroupId { get; set; }
        [Required, Range(1, int.MaxValue)]

        public int Region { get; set; }
        [Required, Range(1, int.MaxValue)]

        public int City { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
    }
}
