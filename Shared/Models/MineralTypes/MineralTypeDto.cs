namespace MoeSystem.Shared.Models.MineralTypes
{
    public class MineralTypeDto : BaseMineralTypeDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
