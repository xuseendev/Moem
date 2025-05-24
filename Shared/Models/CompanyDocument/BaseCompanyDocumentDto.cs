using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.CompanyDocument
{
    public class BaseCompanyDocumentDto
    {
        [Required, Range(1, int.MaxValue)]

        public int DocumentTypeId { get; set; }
        [Required]
        public string DocumentName { get; set; }

        public int? CompanyId { get; set; }
        public string FileExtension { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
