namespace MoeSystem.Server.Data
{
    public class City:BaseModel
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
