namespace MoeSystem.Server.Data
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
