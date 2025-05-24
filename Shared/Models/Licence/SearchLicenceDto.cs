namespace MoeSystem.Shared.Models.Licence
{
    public class SearchLicenceDto : QueryParameters
    {
        public string Name { get; set; }
        public string LicenceId { get; set; }
    }
}
