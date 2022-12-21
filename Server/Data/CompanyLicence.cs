namespace MoeSystem.Server.Data
{
    public class CompanyLicence:BaseModel
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Number { get; set; }

    }
}
