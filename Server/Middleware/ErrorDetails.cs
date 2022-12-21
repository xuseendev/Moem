namespace MoeSystem.Server.Middleware
{
    public class ErrorDetails
    {
        public List<string> Errors { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public string TraceId { get; set; }

    }


}
