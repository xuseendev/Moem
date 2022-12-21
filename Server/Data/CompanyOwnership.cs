namespace MoeSystem.Server.Data
{
    public class CompanyOwnership : BaseModel
    {
      
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string IdType { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Person { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public PersonIdentity PersonIdentity { get; set; }

    }
}
