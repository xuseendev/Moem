using MoeSystem.Shared.Models.Licence;

namespace MoeSystem.Shared.Models.LicenceWorkflow
{
    public class LicenceWorkFlowDto : BaseLicenceWorkFlowDto
    {
        public int Id { get; set; }
        public string WorkFlowName { get; set; }
        public string UserGroup { get; set; }
        public LicenceDto Licence { get; set; }
    }
}
