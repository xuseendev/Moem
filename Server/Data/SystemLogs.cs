namespace MoeSystem.Server.Data
{
    public class SystemLogs : BaseModel
    {
    
        public string ErrorType { get; set; }
        public string Source { get; set; }
        public DateTime Date { get; set; }

        public string StrackTrace { get; set; }
        public string Message { get; set; }
    }
}