using System.Collections.Generic;
using System.Data.Entity;
using zn1Web.Models;

namespace zn1Web.Migrations
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var uczestnicy = new List<Uczestnik>
            {
                new Uczestnik {Imie = "Adam", Nazwisko = "Adam"},
                new Uczestnik {Imie = "Andrzej", Nazwisko = "Andrzej"},
                new Uczestnik {Imie = "Paweł", Nazwisko = "Paweł"},
                new Uczestnik {Imie = "Tomek", Nazwisko = "Tomek"},
                new Uczestnik {Imie = "Kuba", Nazwisko = "Kuba"},
                new Uczestnik {Imie = "Johny", Nazwisko = "Johny"}
            };
            context.Uczestnicy.AddRange(uczestnicy);
            context.SaveChanges();

            var prelegenci = new List<Prelegent>
            {
                new Prelegent {Imie = "P1", Nazwisko = "P1", FotoLink = "http://dup"},
                new Prelegent {Imie = "P2", Nazwisko = "P2", FotoLink = "http://dup"},
                new Prelegent {Imie = "P3", Nazwisko = "P3", FotoLink = "http://dup"},
                new Prelegent {Imie = "P4", Nazwisko = "P4", FotoLink = "http://dup"},
                new Prelegent {Imie = "P5", Nazwisko = "P5", FotoLink = "http://dup"},
                new Prelegent {Imie = "P6", Nazwisko = "P6", FotoLink = "http://dup"}
            };
            context.Prelegenci.AddRange(prelegenci);
            context.SaveChanges();

            var warsztaty = new List<Warsztat>
            {
                new Warsztat {Nazwa = "Wprowadzanie", Sala = "10",MaxOsob = 5, Prelegent1Id = 1}
//                new Warsztat {Id = 2, Nazwa = "Dodawanie", Sala = "5", MaxOsob = 10, PrelegentId = 3},
//                new Warsztat {Id = 3, Nazwa = "Poznawanie", Sala = "3", MaxOsob = 11, PrelegentId = 1}
            };
            context.Warsztaty.AddRange(warsztaty);
            context.SaveChanges();

            var partnerzy = new List<Partner>
            {
                new Partner {LogoLink = "http://dup1", Status = "sadwqdawdas"},
                new Partner {LogoLink = "http://dup2", Status = "sadwqdawdzxceas"},
                new Partner {LogoLink = "http://dup3", Status = "sadwqda12321wdas"}
            };
            context.Partnerzy.AddRange(partnerzy);
            context.SaveChanges();
            
        }
    }
}