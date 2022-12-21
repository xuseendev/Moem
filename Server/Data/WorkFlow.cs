using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Server.Data
{
    public class WorkFlow : BaseModel
    {
   
        public int? LicenceStatusId { get; set; }
        public LicenceStatus LicenceStatus { get; set; }


        public int LicenceTypeId { get; set; }
        public LicenceType LicenceType { get; set; }

        public int? UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        public int Step { get; set; }
        public bool LastStep { get; set; }
        [StringLength(int.MaxValue)]
        public string Activity { get; set; }

        public bool Active { get; set; }
    }
}
