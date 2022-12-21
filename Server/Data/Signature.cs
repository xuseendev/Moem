namespace MoeSystem.Server.Data
{
    public class Signature:BaseModel
    {
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        
    }
}
