using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Workflow
{
    public class WorkFlowDto : BaseWorkFlowDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }=DateTime.Now;
        public string LicenceStatus { get; set; }
        public string LicenceType { get; set; }
        public string UserGroup { get; set; }

    }
}
