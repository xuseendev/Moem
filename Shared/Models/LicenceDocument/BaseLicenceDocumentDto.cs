using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceDocument
{
    public class BaseLicenceDocumentDto
    {
        [Required]

        public int DocumentTypeId { get; set; }
        [Required]

        public string DocumentName { get; set; }
        [Required]


        public int? LicenceId { get; set; }


        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string FileExtension { get; set; }
    }
}
