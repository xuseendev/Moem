namespace MoeSystem.Server.Data
{
    public class UserEventLogs : BaseModel
    {
 
        public string Username { get; set; }
        public DateTime LoggedInTime { get; set; }
        public string LoggedInStatus { get; set; }
        public string UserCountry { get; set; }
        public string UserAgent { get; set; }
        public string UserBranch { get; set; }
        public string UserIPAddress { get; set; }
        public string UserType { get; set; }
    }
}