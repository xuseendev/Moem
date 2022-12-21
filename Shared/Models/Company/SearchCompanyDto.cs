using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Company
{
    public class SearchCompanyDto: QueryParameters
    {
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
