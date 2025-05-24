using MoeSystem.Shared.Models.LicenceTypeTemplate;

namespace MoeSystem.Shared.Models.LicenceTypes
{
    public class LicenceTypeDto : BaseLicenceTypeDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public LicenceTypeTemplateDto LicenceTypeTemplate { get; set; }

    }
}
