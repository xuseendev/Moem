using MoeSystem.Shared.Models.City;

namespace MoeSystem.Shared.Models.Areas
{
    public class AreaDto : BaseAreaDto
    {
        public int Id { get; set; }
        public CityDto City { get; set; }

    }
}
