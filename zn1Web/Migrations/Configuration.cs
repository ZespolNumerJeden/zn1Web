using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using zn1Web.Models;

namespace zn1Web.Migrations
{

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
#if DEBUG
            try
            {
#endif
                Uczestnik.Seed(context.Uczestnicy);
                context.SaveChanges();
                Prelegent.Seed(context.Prelegenci);
                context.SaveChanges();
                Wydarzenie.Seed(context.Wydarzenia);
                context.SaveChanges();
                Partner.Seed(context.Partnerzy);
                context.SaveChanges();
                Warsztat.Seed(context.Warsztaty);
                context.SaveChanges();
                ListaObecnosci.Seed(context.ListyObecnosci);
                context.SaveChanges();
                Bilet.Seed(context.Bilety);
                context.SaveChanges();
#if DEBUG
            }
            catch (DbEntityValidationException e)
            {

                foreach (var err in e.EntityValidationErrors)
                {

                    Debug.WriteLine($"Obiekt typu: {err.Entry.Entity.GetType().Name} w state: {err.Entry.State} ma nastêpuj¹ce b³êdy walidacji:");

                    foreach (var entityErr in err.ValidationErrors)
                    {
                        Debug.WriteLine($"\tProperty: {entityErr.PropertyName} - b³¹d: {entityErr.ErrorMessage}");
                    }

                }
                throw;
            }
#endif
        }
    }
}
