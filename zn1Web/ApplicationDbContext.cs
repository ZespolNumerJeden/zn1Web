using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using zn1Web.Models;

namespace zn1Web
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        #region Tables

        public DbSet<Uczestnik> Uczestnicy { get; set; }
        public DbSet<ListaObecnosci> ListyObecnosci { get; set; }
        public DbSet<Prelegent> Prelegenci { get; set; }
        public DbSet<Warsztat> Warsztaty { get; set; }
        public DbSet<Partner> Partnerzy { get; set; }
        public DbSet<Harmonogram> Harmonogramy { get; set; }
        public DbSet<Wydarzenie> Wydarzenia { get; set; }
        
        #endregion

        public DropCreateDatabaseIfModelChanges<ApplicationDbContext> DbInitializer { get; set; }
        
        public ApplicationDbContext() : base("DefaultConnection", false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // do not append 's to table name
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // define keys for identity models
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new {r.RoleId, r.UserId});
        }
    }
}