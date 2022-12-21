namespace MoeSystem.Server.Data
{
    public class Sytem_Exceptions : BaseModel
    {
     
        public string ErrorType { get; set; }
        public string Source { get; set; }
        public string StrackTrace { get; set; }
        public string Messge { get; set; }
 
    }
}