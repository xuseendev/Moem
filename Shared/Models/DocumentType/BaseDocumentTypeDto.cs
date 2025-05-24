using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.DocumentType
{
    public class BaseDocumentTypeDto
    {
        [Required]

        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
