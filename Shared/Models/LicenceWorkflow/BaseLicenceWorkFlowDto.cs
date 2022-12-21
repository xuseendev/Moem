using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceWorkflow
{
    public class BaseLicenceWorkFlowDto
    {
        public int WorkFlowId { get; set; }
        public int LicenceId { get; set; }
        public bool Status { get; set; }
        public bool Reject { get; set; }
        public int UserGroupId { get; set; }
        public string Activity { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public string TaskActualOwner { get; set; }

    }
}
