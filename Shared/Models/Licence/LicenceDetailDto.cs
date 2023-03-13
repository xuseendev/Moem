using MoeSystem.Shared.Models.Company;
using MoeSystem.Shared.Models.LicenceComment;
using MoeSystem.Shared.Models.LicenceCordinate;
using MoeSystem.Shared.Models.LicenceDocument;
using MoeSystem.Shared.Models.LicenceStatus;
using MoeSystem.Shared.Models.LicenceTypes;
using MoeSystem.Shared.Models.LicenceWorkflow;
using MoeSystem.Shared.Models.Logs;
using MoeSystem.Shared.Models.MineralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Licence
{
    public class LicenceDetailDto : BaseLicenceDto
    {
        public int Id { get; set; }
        public CompanyDto Company { get; set; }
        public LicenceTypeDto LicenceType { get; set; }

        public string MineralType { get; set; }

        //public List<LicenceCommentDto> LicenceComments { get; set; }
        //public List<GetLicenceWorkflowDto> LicenceWorkFlows { get; set; }
        //public List<LicenceCordinateDto> LicenceCordinates { get; set; }
        public List<LicenceStatusDto> LicenceStatuses { get; set; }
        //public List<LicenceDocumentDto> LicenceDocuments { get; set; }
        //public List<BaseLogsDto> Logs { get; set; }

        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
    }
}
