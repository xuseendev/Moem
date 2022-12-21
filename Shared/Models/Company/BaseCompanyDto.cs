using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Company
{
    public class BaseCompanyDto
    {
        public int CompanyId { get; set; }
        public int CompanyTypeId { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        public int RegionId { get; set; }

        public int CityId { get; set; }

        public string Email { get; set; }
        public string TellPhone { get; set; }

    }
}
