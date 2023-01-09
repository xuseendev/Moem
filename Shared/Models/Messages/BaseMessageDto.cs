using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Messages
{
    public class BaseMessageDto
    {
        [Required]

        public string Name { get; set; }
        [Required]

        public string Type { get; set; }
        [Required]

        public string Body { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
