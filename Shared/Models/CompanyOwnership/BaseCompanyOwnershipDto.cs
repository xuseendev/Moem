using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.CompanyOwnership
{
    public class BaseCompanyOwnershipDto
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]

        public int PersonId { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public string Phone { get; set; }
        [Required]

        public string IdType { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
