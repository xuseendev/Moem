using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceComment
{
    public class BaseLicenceCommentDto
    {
        public string Comment { get; set; }
        public int LicenceId { get; set; }
        public string Type { get; set; }

    }
}
