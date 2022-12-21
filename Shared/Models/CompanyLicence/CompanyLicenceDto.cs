using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.CompanyLicence
{
    public class CompanyLicenceDto : BaseCompanyLicenceDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string TellPhone { get; set; }
    }
}
