namespace MoeSystem.Server.Data
{
    public class LicenceStatus : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Active { get; set; }
        public string Type { get; set; }

    }
}
