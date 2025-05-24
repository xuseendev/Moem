namespace MoeSystem.Shared.Models.Licence
{
    public class SearchLicenceDetailDto
    {
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string LicenceId { get; set; }
        public string LicenceStatus { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}