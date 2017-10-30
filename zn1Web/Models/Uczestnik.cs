using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace zn1Web.Models
{
    public class Uczestnik
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Imie { get; set; }

        [StringLength(50)]
        public string Nazwisko { get; set; }

        [StringLength(50)]
        public string Firma { get; set; }

        [StringLength(50)]
        public string Stanowisko { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool PotwPlatnosci { get; set; }
        public bool PotwObecnosci { get; set; }

        [StringLength(20)]
        public string Obiad { get; set; }

        #region Seed

        /// <summary>
        /// Seeds table Uczestnicy with mock data.
        /// </summary>
        /// <param name="table">Uczestnicy table.</param>
        internal static void Seed(DbSet<Uczestnik> table)
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
            table.AddRange(uczestnicy);
        }

        #endregion

    }

}