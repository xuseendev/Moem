namespace MoeSystem.Server.Data
{
    public class Area :BaseModel
    {

        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
