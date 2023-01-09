﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.CompanyDocument
{
    public class BaseCompanyDocumentDto
    {
        [Required]
        public int DocumentTypeId { get; set; }
        [Required]
        public string DocumentName { get; set; }

        public int? CompanyId { get; set; }
        public string FileExtension { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
