using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.DocumentType
{
    public class BaseDocumentTypeDto
    {
        [Required]

        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
