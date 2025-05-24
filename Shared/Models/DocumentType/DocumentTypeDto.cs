namespace MoeSystem.Shared.Models.DocumentType
{
    public class DocumentTypeDto : BaseDocumentTypeDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
