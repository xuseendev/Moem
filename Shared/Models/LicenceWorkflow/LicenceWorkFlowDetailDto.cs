using MoeSystem.Shared.Models.Licence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceWorkflow
{
    public class LicenceWorkFlowDetailDto : BaseLicenceWorkFlowDto
    {
        public int Id { get; set; }
        public string WorkFlowName { get; set; }
        public string UserGroup { get; set; }


    }
}
