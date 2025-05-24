using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.City
{
    public class BaseCityDto
    {
        [Required]
        public string Name { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int RegionId { get; set; }

        public bool Active { get; set; }
    }
}
