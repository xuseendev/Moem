using System.ComponentModel.DataAnnotations;
using MoeSystem.Shared.Models.UserGroup;

namespace MoeSystem.Shared.Models.Signature
{
    public class BaseSignatureDto
    {
        [Required, Range(1, int.MaxValue)]


        public int UserGroupId { get; set; }

        public UserGroupDto UserGroup { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public string Name { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }


    }
}