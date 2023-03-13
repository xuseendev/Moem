﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Region
{
    public class BaseRegionDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Code { get; set; }

    }
}
