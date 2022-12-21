namespace MoeSystem.Server.Data
{
    public class CompanyDocument : BaseModel
    {
    
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentName { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public byte[] File { get; set; }



        public string FileExtension { get; set; }


    }
}
