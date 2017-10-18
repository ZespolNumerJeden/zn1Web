namespace zn1Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<zn1Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(zn1Web.Models.ApplicationDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//		context.Uczestnik.AddOrUpdate(
			//      u => u.Id,
			//      new Uczestnik() { Id = 1, Imie = "Adam", Nazwisko = "Adam" },
			//      new Uczestnik() { Id = 2, Imie = "Andrzej", Nazwisko = "Andrzej" },
			//      new Uczestnik() { Id = 3, Imie = "Pawe³", Nazwisko = "Pawe³" },
			//      new Uczestnik() { Id = 4, Imie = "Tomek", Nazwisko = "Tomek" },
			//      new Uczestnik() { Id = 5, Imie = "Kuba", Nazwisko = "Kuba" },
			//      new Uczestnik() { Id = 6, Imie = "Johny", Nazwisko = "Johny" },
			//    );
			//		context.Prelegent.AddOrUpdate(
			//      p => p.Id,
			//      new Prelegent() { Id = 1, Imie = "P1", Nazwisko = "P1", FotoLink = "asdqwdaswewdaesda"},
			//      new Prelegent() { Id = 2, Imie = "P2", Nazwisko = "P2", FotoLink = "asdqwdasweqweqwewdaesda"},
			//      new Prelegent() { Id = 3, Imie = "P3", Nazwisko = "P3", FotoLink = "asdqwdaswewasddaesda"},
			//      new Prelegent() { Id = 4, Imie = "P4", Nazwisko = "P4", FotoLink = "asdqwdasweasdwdaesda"},
			//      new Prelegent() { Id = 5, Imie = "P5", Nazwisko = "P5", FotoLink = "asdqwdasweadqwwdaesda"},
			//      new Prelegent() { Id = 6, Imie = "P6", Nazwisko = "P6", FotoLink = "asdqwdasweeqwewdaesda"},
			//		);
			//		context.Warsztat.AddOrUpdate(
			//      w => w.Id,
			//      new Warsztat() { Id = 1, Nazwa = "Wprowadzanie", Sala = "10", MaxOsob = 5, PrelegentId = 2},
			//      new Warsztat() { Id = 2, Nazwa = "Dodawanie", Sala = "5", MaxOsob = 10, PrelegentId = 3},
			//      new Warsztat() { Id = 3, Nazwa = "Poznawanie", Sala = "3", MaxOsob = 11, PrelegentId = 1},
			//    );
			//		context.Partner.AddOrUpdate(
			//      p => p.Id,
			//      new Partner() { Id = 1, LogoLink = "asddadadadadadadadada", Status = "sadwqdawdas"},
			//      new Partner() { Id = 2, LogoLink = "asddadadadadadadasdasdadada", Status = "sadwqdawdzxceas"},
			//      new Partner() { Id = 3, LogoLink = "asddadadadadadadadq12321adada", Status = "sadwqda12321wdas"},
			//    );
		}
	}
}
