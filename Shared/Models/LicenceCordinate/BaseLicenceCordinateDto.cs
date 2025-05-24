using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.LicenceCordinate
{
    public class BaseLicenceCordinateDto
    {
        [Required]

        public int LicenceId { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Lat { get; set; }
        [Required]

        public string Lng { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
