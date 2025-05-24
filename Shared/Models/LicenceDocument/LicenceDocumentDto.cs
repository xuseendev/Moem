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
