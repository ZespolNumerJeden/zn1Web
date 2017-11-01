using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace zn1Web.Models
{
    public class ListaObecnosci
    {
        public int Id { get; set; }

        public Uczestnik Uczestnik { get; set; }
        public int UczestnikId { get; set; }

        public Warsztat Warsztat { get; set; }
        public int WarsztatId { get; set; }

        public DateTime? Rejestracja { get; set; }
        public bool Obecnosc { get; set; }

        // wydarzenie
        public Wydarzenie Wydarzenie { get; set; }
        public int? WydarzenieId { get; set; }

        #region Seed

        /// <summary>
        /// Seeds table with mock data.
        /// </summary>
        /// <param name="table">Table Warsztaty</param>
        internal static void Seed(DbSet<ListaObecnosci> table)
        {
            var obecnosci = new List<ListaObecnosci>
            {
                new ListaObecnosci {Obecnosc = true, UczestnikId = 2, WarsztatId = 3, Rejestracja = DateTime.Now, WydarzenieId = 2},
                new ListaObecnosci {Obecnosc = true, UczestnikId = 1, WarsztatId = 1, Rejestracja = new DateTime(2017, 10, 21), WydarzenieId = 2},
                new ListaObecnosci {Obecnosc = true, UczestnikId = 4, WarsztatId = 2, Rejestracja = new DateTime(2017, 10, 22), WydarzenieId = 2},
                new ListaObecnosci {UczestnikId = 2, WarsztatId = 2, WydarzenieId = 2}
            };
            table.AddRange(obecnosci);
        }

        #endregion
    }
}