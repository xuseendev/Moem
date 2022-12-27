using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.CompanyOwnership
{
    public class BaseCompanyOwnershipDto
    {
        public int CompanyId { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string IdType { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
