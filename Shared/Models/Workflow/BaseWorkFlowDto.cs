using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models.Workflow
{
    public class BaseWorkFlowDto
    {
       [Required, Range(1, int.MaxValue)]


        public int LicenceStatusId { get; set; }
        [Required, Range(1, int.MaxValue)]


        public int LicenceTypeId { get; set; }
    [Required, Range(1, int.MaxValue)]


        public int UserGroupId { get; set; }
        [Required]

        public int Step { get; set; }
        public bool Active { get; set; }
        [Required]

        public string Activity { get; set; }
        public bool LastStep { get; set; }

    }
}
