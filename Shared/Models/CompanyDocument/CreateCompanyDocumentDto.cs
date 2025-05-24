namespace MoeSystem.Shared.Models.CompanyDocument
{
    public class CreateCompanyDocumentDto : BaseCompanyDocumentDto
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }

    }
}
