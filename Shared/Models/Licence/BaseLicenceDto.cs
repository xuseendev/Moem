﻿using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.Licence
{
    public class BaseLicenceDto
    {
        public int LicenceId { get; set; }

        public int CompanyId { get; set; }

        [Required, Range(1, int.MaxValue)]

        public int LicenceTypeId { get; set; }
        [Required]

        public string TermOfTheLicence { get; set; }
        public DateTime? LicenceStartDate { get; set; }
        public DateTime? LicenceEndDate { get; set; }
        [Required, Range(1, int.MaxValue)]


        public int MineralTypeId { get; set; }
        public string Status { get; set; }
        public string LicenceStatus { get; set; } = "Registered";
        [Required]
        public string Note { get; set; }
        [Required, Range(1, int.MaxValue)]

        public int RegionId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int CityId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int AreaId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }

    }
}
