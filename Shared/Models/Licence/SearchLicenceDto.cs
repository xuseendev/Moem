using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Licence
{
    public class SearchLicenceDto: QueryParameters
    {
        public string Name { get; set; }
        public string LicenceId { get; set; }
    }
}
