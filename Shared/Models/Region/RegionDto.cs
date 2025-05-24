namespace MoeSystem.Shared.Models.Region
{
    public class RegionDto : BaseRegionDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
