using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Company
{
    public class BaseCompanyDto
    {
        [Required]
        public int CompanyId { get; set; }


        public int CompanyTypeId { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Type { get; set; }
        [Required, Range(1, int.MaxValue)]

        public int RegionId { get; set; }
        [Required, Range(1, int.MaxValue)]


        public int CityId { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]


        public string Email { get; set; }
        [Required]

        public string TellPhone { get; set; }

    }
}
