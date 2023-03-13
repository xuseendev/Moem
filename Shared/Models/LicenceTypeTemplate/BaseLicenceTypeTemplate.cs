using System.ComponentModel.DataAnnotations;
using MoeSystem.Shared.Models.LicenceTypes;

namespace MoeSystem.Shared.Models.LicenceTypeTemplate
{
    public class BaseLicenceTypeTemplate
    {

        [Required]

        public string Title { get; set; }
        [Required]

        public string SubTitle { get; set; }
        [Required]


        public string Note { get; set; }
        [Required]

        public string SubNote { get; set; }


        public bool ShowCordinate { get; set; }
        [Required]


        public int SignatureId { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        // public Signat Signature { get; set; }
    }
}