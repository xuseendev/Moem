namespace MoeSystem.Server.Data
{
    public class Messages : BaseModel
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public bool Active { get; set; }

    }
}