using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTicketsPlugin.Server.Models;

namespace MyTicketsPlugin.Server.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
           var hasher = new PasswordHasher<ApplicationUser>();
           var pass = hasher.HashPassword(null, "P@ssword1");

           builder.HasData(
           new ApplicationUser
           {
               Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
               Email = "admin@localhost.com",
               NormalizedEmail = "ADMIN@LOCALHOST.COM",
               FirstName = "Admin",
               LastName = "Suporte",
               UserName = "admin@localhost.com",
               NormalizedUserName = "ADMIN@LOCALHOST.COM",
               PasswordHash = pass
           },
             new ApplicationUser
             {
                 Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                 Email = "user@localhost.com",
                 NormalizedEmail = "USER@LOCALHOST.COM",
                 FirstName = "User",
                 LastName = "System",
                 UserName = "user@localhost.com",
                 NormalizedUserName = "USER@LOCALHOST.COM",
                 PasswordHash = pass
             }
            );
        }

    }
}
