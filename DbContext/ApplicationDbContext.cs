using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyRent.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;
namespace MyRent.DbContext
{
    public class ApplicationDbContext: IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Owner> owners { get; set; }
        public DbSet<Renter> renters { get; set; }

       // public DbSet<AppUser> appuser { get; set; }

        public DbSet<Apartment> apartments { get; set; }

        public DbSet<Payment> payments { get; set; }

        public DbSet<Images> images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Owner>()
            .ToTable("Owners");



            builder.Entity<Renter>()
                .ToTable("Renters");
               
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "ADMIN",

                },
                new IdentityRole
                {
                    Name = "Owner",
                    NormalizedName = "OWNER",

                },
                new IdentityRole
                {
                    Name = "renter",
                    NormalizedName = "RENTER",

                }

            };
            builder.Entity<IdentityRole>().HasData(roles);

        }

        }
}
