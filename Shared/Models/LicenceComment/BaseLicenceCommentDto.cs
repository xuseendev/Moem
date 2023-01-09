using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.LicenceComment
{
    public class BaseLicenceCommentDto
    {
        [Required]

        public string Comment { get; set; }
        [Required]

        public int LicenceId { get; set; }
        [Required]

        public string Type { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
