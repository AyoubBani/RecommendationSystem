using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RecommandationApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual Representant Representant { get; set; }
        public virtual Client Client { get; set; }

        [Display(Name = "Representant")]
        public bool is_representant { get; set; }        

        //        [Display(Name = "Client")]
        //        public bool is_client { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Representant> Representants { get; set; }
        public DbSet<Client> Clients { get; set; }
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<RecommandationApp.Models.Offre> Offres { get; set; }

        public System.Data.Entity.DbSet<RecommandationApp.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<RecommandationApp.Models.Rating> Ratings { get; set; }
        public System.Data.Entity.DbSet<RecommandationApp.Models.CategoryM> CategoryMs { get; set; }
    }
}