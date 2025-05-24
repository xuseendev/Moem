using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.UserGroup
{
    public class BaseUserGroupDto
    {
        [Required]

        public string Name { get; set; }
        [Required]

        public string InSomali { get; set; }
        public bool Active { get; set; }
    }
}
