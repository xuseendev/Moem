using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoeSystem.Shared.Models.Company;

namespace MoeSystem.Shared.Models.Licence
{
    public class CreateLicenceDto : BaseLicenceDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string TellPhone { get; set; }
        public CompanyDto Company { get; set; }
    }
}
