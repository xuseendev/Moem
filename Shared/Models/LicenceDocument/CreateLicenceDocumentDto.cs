namespace MoeSystem.Shared.Models.LicenceDocument
{
    public class CreateLicenceDocumentDto : BaseLicenceDocumentDto
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }

    }
}
