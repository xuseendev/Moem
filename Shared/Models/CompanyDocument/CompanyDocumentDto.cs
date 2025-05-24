namespace MoeSystem.Shared.Models.CompanyDocument
{
    public class CompanyDocumentDto : BaseCompanyDocumentDto
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        //public CompanyDto Company { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
