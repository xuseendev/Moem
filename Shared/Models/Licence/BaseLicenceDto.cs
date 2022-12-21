using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Licence
{
    public class BaseLicenceDto
    {
        [Required, Range(1, int.MaxValue)]

        public int LicenceId { get; set; }
        [Required, Range(1, int.MaxValue)]


        public int CompanyId { get; set; }
        [Required, Range(1, int.MaxValue)]

        public int LicenceTypeId { get; set; }
        [Required]

        public string TermOfTheLicence { get; set; }
        public DateTime? LicenceStartDate { get; set; }
        public DateTime LicenceEndDate { get; set; }
        [Required, Range(1, int.MaxValue)]


        public int MineralTypeId { get; set; }
        public string Status { get; set; }
        public string LicenceStatus { get; set; } = "Registered";
        [Required]
        public string Note { get; set; }

        public int RegionId { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }

    }
}
