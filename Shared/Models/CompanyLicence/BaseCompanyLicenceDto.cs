﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.CompanyLicence
{
    public class BaseCompanyLicenceDto
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime? IssueDate { get; set; }
        [Required]
        public DateTime? ExpireDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
