using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.LicenceStatus
{
    public class BaseLicenceStatusDto
    {
        [Required]

        public string Name { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
    }
}
