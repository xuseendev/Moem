using MoeSystem.Shared.Models.LicenceTypes;

namespace MoeSystem.Shared.Models.LicenceTypeTemplate
{
    public class BaseLicenceTypeTemplate
    {
        public int LicenceTypeId { get; set; }
        public LicenceTypeDto LicenceType { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string Note { get; set; }
        public string SubNote { get; set; }
        public bool ShowCordinate { get; set; }

        public int SignatureId { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        // public Signat Signature { get; set; }
    }
}