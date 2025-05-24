using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.CompanyTypes
{
    public class BaseCompanyTypeDto
    {
        [Required]

        public string Name { get; set; }
        public bool Active { get; set; }

    }
}
