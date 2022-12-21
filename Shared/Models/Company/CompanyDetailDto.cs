using MoeSystem.Shared.Models.Areas;
using MoeSystem.Shared.Models.City;
using MoeSystem.Shared.Models.CompanyDocument;
using MoeSystem.Shared.Models.CompanyLicence;
using MoeSystem.Shared.Models.CompanyOwnership;
using MoeSystem.Shared.Models.CompanyTypes;
using MoeSystem.Shared.Models.Licence;
using MoeSystem.Shared.Models.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Company
{
    public class CompanyDetailDto : BaseCompanyDto
    {
        public int Id { get; set; }
        public string Regoin { get; set; }
        public string City { get; set; }
        public string CompanyType { get; set; }

        public List<CompanyOwnershipDto> CompanyOwnerships { get; set; }
        //public List<CompanyDocumentDto> CompanyDocuments { get; set; }
        public List<CompanyLicenceDto> CompanyLicences { get; set; }
        public List<LicenceDto> Licences { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
