namespace MoeSystem.Server.Data
{
    public class LicenceDocument:BaseModel
    {
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentName { get; set; }

        public int? LicenceId { get; set; }
        public Licence Licence { get; set; }
        public byte[] File { get; set; }



        public string FileExtension { get; set; }
    }
}
