namespace MoeSystem.Server.Data
{
    public class UserLogs : BaseModel
    {
  
        public string Description { get; set; }
        public string Identifier { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string UserId { get; set; }
        public string UserEventType { get; set; }
    }
}