using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceStatus
{
    public class BaseLicenceStatusDto
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
    }
}
