using MoeSystem.Shared.Models.Company;
using MoeSystem.Shared.Models.DocumentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceDocument
{
    public class LicenceDocumentDto : BaseLicenceDocumentDto
    {
        public int Id { get; set; }
        //public DocumentTypeDto DocumentType { get; set; }
        public string DocumentType { get; set; }
        //public CompanyDto Company { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
