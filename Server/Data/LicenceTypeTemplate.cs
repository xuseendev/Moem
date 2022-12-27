using MoeSystem.Server.Data;

namespace MoeSystem.Server.Data
{
    public class LicenceTypeTemplate : BaseModel
    {

        public int LicenceTypeId { get; set; }
        public LicenceType LicenceType { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string Note { get; set; }
        public string SubNote { get; set; }
        public bool ShowCordinate { get; set; }

        public int SignatureId { get; set; }
        public Signature Signature { get; set; }

    }
}