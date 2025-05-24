using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.Areas
{
    public class BaseAreaDto
    {
        [Required]
        public string Name { get; set; }
        [Required, Range(1, int.MaxValue)]

        public int CityId { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
    }
}
