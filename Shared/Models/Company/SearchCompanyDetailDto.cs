using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Company
{
    public class SearchCompanyDetailDto : QueryParameters
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CompanyId { get; set; }
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}
