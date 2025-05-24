using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.MineralTypes
{
    public class BaseMineralTypeDto
    {
        [Required]

        public string Name { get; set; }
        public bool Active { get; set; }

    }
}
