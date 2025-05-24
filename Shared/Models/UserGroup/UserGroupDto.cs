namespace MoeSystem.Shared.Models.UserGroup
{
    public class UserGroupDto : BaseUserGroupDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
