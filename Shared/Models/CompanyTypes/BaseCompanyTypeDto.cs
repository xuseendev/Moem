using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.CompanyTypes
{
    public class BaseCompanyTypeDto
    {
        [Required]

        public string Name { get; set; }
        public bool Active { get; set; }

    }
}
