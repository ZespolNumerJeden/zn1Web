using System.Collections.Generic;
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
                var uczestnicy = new List<Uczestnik>
                {
                    new Uczestnik {Imie = "Adam", Nazwisko = "Adam"},
                    new Uczestnik {Imie = "Andrzej", Nazwisko = "Andrzej"},
                    new Uczestnik {Imie = "Pawe³", Nazwisko = "Pawe³"},
                    new Uczestnik {Imie = "Tomek", Nazwisko = "Tomek"},
                    new Uczestnik {Imie = "Kuba", Nazwisko = "Kuba"},
                    new Uczestnik {Imie = "Johny", Nazwisko = "Johny"}
                };
                context.Uczestnicy.AddRange(uczestnicy);
                context.SaveChanges();

                var prelegenci = new List<Prelegent>
                {
                    new Prelegent {Imie = "P1", Nazwisko = "P1", FotoLink = "http://dup.a/pl"},
                    new Prelegent {Imie = "P2", Nazwisko = "P2", FotoLink = "http://dup.a/pl"},
                    new Prelegent {Imie = "P3", Nazwisko = "P3", FotoLink = "http://dup.a/pl"},
                    new Prelegent {Imie = "P4", Nazwisko = "P4", FotoLink = "http://dup.a/pl"},
                    new Prelegent {Imie = "P5", Nazwisko = "P5", FotoLink = "http://dup.a/pl"},
                    new Prelegent {Imie = "P6", Nazwisko = "P6", FotoLink = "http://dup.a/pl"}
                };
                context.Prelegenci.AddRange(prelegenci);
                context.SaveChanges();

                var warsztaty = new List<Warsztat>
                {
                    new Warsztat {Nazwa = "Wprowadzanie", Sala = "10", Prelegent1Id = 1, Prelegent2Id = 2},
                    new Warsztat {Nazwa = "Dodawanie", Sala = "5", MaxOsob = 10, Prelegent1Id = 3},
                    new Warsztat {Nazwa = "Poznawanie", Sala = "3", MaxOsob = 11, Prelegent1Id = 1}
                };
                context.Warsztaty.AddRange(warsztaty);
                context.SaveChanges();

                var partnerzy = new List<Partner>
                {
                    new Partner {LogoLink = "http://dup1.a/pl", Status = "sadwqdawdas"},
                    new Partner {LogoLink = "http://dup2.a/pl", Status = "sadwqdawdzxceas"},
                    new Partner {LogoLink = "http://dup3.a/pl", Status = "sadwqda12321wdas"}
                };
                context.Partnerzy.AddRange(partnerzy);
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
