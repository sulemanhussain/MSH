using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MSH.Entities.AppDBContext
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext() : base()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Distribution> Distribution { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<Common.Category> Category { get; set; }
        public DbSet<QnA.Query> Query { get; set; }

        //public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}