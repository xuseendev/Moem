using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.CompanyLicence
{
    public class BaseCompanyLicenceDto
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime? IssueDate { get; set; }
        [Required]
        public DateTime? ExpireDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
