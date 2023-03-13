namespace MoeSystem.Server.Data
{
    public class LicenceType : BaseModel
    {
        public int? LicenceTypeTemplateId { get; set; }
        public LicenceTypeTemplate LicenceTypeTemplate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TermOfLicence { get; set; }
        public int LicencePeriod { get; set; }
        public string LicencePeriodType { get; set; }

        public string Description { get; set; }
        public bool Active { get; set; }

    }
}
