using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceDocument
{
    public class LicenceDocumentDetailDto:BaseLicenceDocumentDto
    {
        public byte[] File { get; set; }

    }
}
