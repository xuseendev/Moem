namespace MoeSystem.Shared.Models.CompanyTypes
{
    public class CompanyTypeDto : BaseCompanyTypeDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
