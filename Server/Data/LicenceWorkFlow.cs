namespace MoeSystem.Server.Data
{
    public class LicenceWorkFlow : BaseModel
    {

        public int WorkFlowId { get; set; }
        public WorkFlow WorkFlow { get; set; }
        public int? LicenceId { get; set; }
        public Licence Licence { get; set; }
        public int Step { get; set; }
        public bool Status { get; set; }
        public bool Reject { get; set; }
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        public string Activity { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public string TaskActualOwner { get; set; }


    }
}
