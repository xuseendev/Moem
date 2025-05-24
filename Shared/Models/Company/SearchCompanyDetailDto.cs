namespace MoeSystem.Shared.Models.Company
{
    public class SearchCompanyDetailDto : QueryParameters
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}
