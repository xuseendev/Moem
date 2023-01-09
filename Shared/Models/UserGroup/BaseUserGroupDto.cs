using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.UserGroup
{
    public class BaseUserGroupDto
    {
        [Required]

        public string Name { get; set; }
        [Required]

        public string InSomali { get; set; }
        public bool Active { get; set; }
    }
}
