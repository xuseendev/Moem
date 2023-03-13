using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Licence
{
    public class LicenceDto : BaseLicenceDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string LicenceType { get; set; }
        public string MineralType { get; set; }
        public string TellPhone { get; set; }

    }
}
