namespace MoeSystem.Server.Data
{
    public class Licence : BaseModel
    {

        public int LicenceId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int LicenceTypeId { get; set; }
        public LicenceType LicenceType { get; set; }
        public string TermOfTheLicence { get; set; }
        public DateTime LicenceStartDate { get; set; }
        public DateTime LicenceEndDate { get; set; }
        public int MineralTypeId { get; set; }
        public MineralType MineralType { get; set; }
        public int? RegionId { get; set; }
        public Region Region { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public int? AreaId { get; set; }
        public Area Area { get; set; }

        public string Status { get; set; }
        public string LicenceStatus { get; set; }
        public string Note { get; set; }

        //public List<LicenceComments> LicenceComments { get; set; }
        public List<LicenceCordinates> LicenceCordinates { get; set; }
        // public List<LicenceWorkFlow> LicenceWorkFlows { get; set; }
        public List<LicenceStatus> LicenceStatuses { get; set; }
        //public List<LicenceDocument> LicenceDocuments{ get; set; }
        //public List<Logs> Logs{ get; set; }

    }
}
