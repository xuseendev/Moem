using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using MoeSystem.Client.Services.Base;


namespace MoeSystem.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<LicenceTypeTemplate> LicenceTypeTemplates { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyDocument> CompanyDocuments { get; set; }
        public DbSet<LicenceDocument> LicenceDocument { get; set; }
        public DbSet<CompanyOwnership> CompanyOwnerships { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<LicenceComments> LicenceComments { get; set; }
        public DbSet<LicenceCordinates> LicenceCordinates { get; set; }
        public DbSet<LicenceStatus> LicenceStatuses { get; set; }
        public DbSet<LicenceWorkFlow> LicenceWorkFlows { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<MineralType> MineralTypes { get; set; }
        public DbSet<PersonIdentity> PersonIdentities { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<SystemLogs> SystemLogs { get; set; }
        public DbSet<Sytem_Exceptions> SystemExceptions { get; set; }
        public DbSet<UserEventLogs> UserEventLogs { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserLogs> UserLogs { get; set; }
        public DbSet<WorkFlow> WorkFlow { get; set; }
        public DbSet<LicenceType> LicenceType { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<CompanyLicence> CompanyLicences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Id = "4cfa23fd-542d-4ade-951e-a3da08eff315",
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR",

               },
               new IdentityRole
               {
                   Id = "bbb0aca2-2d5f-4466-b8df-52f12467afe5",
                   Name = "User",
                   NormalizedName = "USER",

               }
               );
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "2419fb85-daf3-47a6-9af3-1c1bc5dfd248",
                Email = "admin@moem.com",
                NormalizedEmail = "ADMIN@MOEM.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "Admin@@123")

            });


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                 new IdentityUserRole<string>
                 {
                     RoleId = "4cfa23fd-542d-4ade-951e-a3da08eff315",
                     UserId = "2419fb85-daf3-47a6-9af3-1c1bc5dfd248"
                 }
                );


        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var userId = await User.GetUsername();

        //    var entries = base.ChangeTracker.Entries()
        //        .Where(q => q.State == EntityState.Modified || q.State == EntityState.Added);
        //    foreach (var entry in entries)
        //    {
        //        //if(entry.State== EntityState.Modified)
        //        //((BaseModel)entry.Entity).UpdatedOn = DateTime.Now;
        //        //if (entry.State == EntityState.Added)
        //        //{
        //        //    ((BaseModel)entry.Entity).CreatedOn = DateTime.Now;

        //        //}

        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}


    }
}
