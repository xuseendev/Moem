using MoeSystem.Shared.Models.Region;

namespace MoeSystem.Shared.Models.City
{
    public class CityDto : BaseCityDto
    {
        public int Id { get; set; }
        public RegionDto Region { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
