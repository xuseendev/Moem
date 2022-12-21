using MoeSystem.Shared.Models.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.City
{
    public class BaseCityDto
    {
        public string Name { get; set; }
        public int RegionId { get; set; }

        public bool Active { get; set; }
    }
}
