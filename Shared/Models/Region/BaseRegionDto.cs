using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.Region
{
    public class BaseRegionDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Code { get; set; }

    }
}
