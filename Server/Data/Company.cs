namespace MoeSystem.Server.Data
{
    public class Company : BaseModel
    {

        public int CompanyId { get; set; }
        public int? CompanyTypeId { get; set; }
        public CompanyType CompanyType { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        public int? RegionId { get; set; }
        public Region Regoin { get; set; }
        public int? CityId { get; set; }

        public City City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TellPhone { get; set; }

        public List<CompanyOwnership> CompanyOwnerships { get; set; }
        public List<CompanyDocument> CompanyDocuments { get; set; }
        public List<Licence> Licences { get; set; }
        public List<CompanyLicence> CompanyLicences { get; set; }


    }
}
