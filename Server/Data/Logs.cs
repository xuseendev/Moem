using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Server.Data
{
    public class Logs : BaseModel
    {

        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dated { get; set; }

        public int? CompanyId { get; set; }
        public int? LicenceId { get; set; }
        public Company Company { get; set; }
        public Licence Licence { get; set; }



    }
}