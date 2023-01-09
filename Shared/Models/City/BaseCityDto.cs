using MoeSystem.Shared.Models.Region;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.City
{
    public class BaseCityDto
    {
        [Required]
        public string Name { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int RegionId { get; set; }

        public bool Active { get; set; }
    }
}
