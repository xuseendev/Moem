namespace MoeSystem.Server.Data
{
    public class PersonIdentity : BaseModel
    {

     
        public int CompanyOwnershipId { get; set; }
        public virtual CompanyOwnership CompanyOwnership { get; set; }
        public byte[] File { get; set; }
        public string FileExtension { get; set; }
        public string IdType { get; set; }
        public int IdNumber { get; set; }

    }
}
