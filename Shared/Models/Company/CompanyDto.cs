namespace MoeSystem.Shared.Models.Company
{
    public class CompanyDto : BaseCompanyDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CompanyType { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
    }
}
