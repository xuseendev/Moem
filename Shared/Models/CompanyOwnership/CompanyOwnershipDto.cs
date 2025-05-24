namespace MoeSystem.Shared.Models.CompanyOwnership
{
    public class CompanyOwnershipDto : BaseCompanyOwnershipDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
