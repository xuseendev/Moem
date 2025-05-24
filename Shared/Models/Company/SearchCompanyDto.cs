namespace MoeSystem.Shared.Models.Company
{
    public class SearchCompanyDto : QueryParameters
    {
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
