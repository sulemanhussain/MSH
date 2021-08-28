using Microsoft.AspNetCore.Identity;

namespace MSH.Entities.IdentityExtensions
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }

    public enum UserRole
    {
        SuperUser,
        Admin,
        Normal
    }
}
