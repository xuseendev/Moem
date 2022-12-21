using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Workflow
{
    public class BaseWorkFlowDto
    {
        public int LicenceStatusId { get; set; }
        public int LicenceTypeId { get; set; }
        public int UserGroupId { get; set; }
        public int Step { get; set; }
        public bool Active { get; set; }
        public string Activity { get; set; }
        public bool LastStep { get; set; }

    }
}
