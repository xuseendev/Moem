using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceWorkflow
{
    public class GetLicenceWorkflowDto : BaseLicenceWorkFlowDto
    {
        public int Id { get; set; }
        public string WorkFlowName { get; set; }
        public string UserGroup { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public string TaskActualOwner { get; set; }
    }
}
