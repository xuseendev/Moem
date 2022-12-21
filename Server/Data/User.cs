using Microsoft.AspNetCore.Identity;

namespace MoeSystem.Server.Data
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public int? UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
