﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceTypes
{
    public class BaseLicenceTypeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]


        public string TermOfLicence { get; set; }
        [Required, Range(0, 12)]

        public int LicencePeriod { get; set; }
        [Required]

        public string LicencePeriodType { get; set; }
        [Required]

        public string Description { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int LicenceTypeTemplateId { get; set; }

        public bool Active { get; set; }
    }
}
