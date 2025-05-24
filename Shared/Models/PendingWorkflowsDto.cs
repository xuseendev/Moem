namespace MoeSystem.Shared.Models
{
    public class PendingWorkflowsDto
    {
        public string UserGroup { get; set; }
        public string InSomali { get; set; }
        public decimal InClaim { get; set; }
        public int InProgress { get; set; }
        public int Completed { get; set; }
    }
}
