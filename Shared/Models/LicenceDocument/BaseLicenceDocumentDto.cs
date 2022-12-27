using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceDocument
{
    public class BaseLicenceDocumentDto
    {
        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }

        public int? LicenceId { get; set; }


        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string FileExtension { get; set; }
    }
}
