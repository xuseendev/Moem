using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.CompanyDocument
{
    public class BaseCompanyDocumentDto
    {
        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }

        public int? CompanyId { get; set; }
      



        public string FileExtension { get; set; }
    }
}
