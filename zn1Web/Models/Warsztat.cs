using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace zn1Web.Models
{
    public class Warsztat
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Nazwa { get; set; }

        [StringLength(500)]
        public string Opis { get; set; }

        [StringLength(10)]
        public string Sala { get; set; }

        public int? MaxOsob { get; set; }

        // wydarzenie
        public Wydarzenie Wydarzenie { get; set; }
        public int? WydarzenieId { get; set; }

        // Prelegent 1
        public Prelegent Prelegent1 { get; set; }
        public int? Prelegent1Id { get; set; }

        // Prelegent 2
        public Prelegent Prelegent2 { get; set; }
        public int? Prelegent2Id { get; set; }

        // Prelegent 3
        public Prelegent Prelegent3 { get; set; }
        public int? Prelegent3Id { get; set; }

        #region Seed

        /// <summary>
        /// Seeds tavle with mock data.
        /// </summary>
        /// <param name="table">Table Warsztaty</param>
        internal static void Seed(DbSet<Warsztat> table)
        {
            var warsztaty = new List<Warsztat>
            {
                new Warsztat {Nazwa = "Wprowadzanie", Sala = "10", Prelegent1Id = 1, Prelegent2Id = 2, WydarzenieId = 2},
                new Warsztat {Nazwa = "Dodawanie", Sala = "5", MaxOsob = 10, Prelegent1Id = 3, WydarzenieId = 2},
                new Warsztat {Nazwa = "Poznawanie", Sala = "3", MaxOsob = 11, Prelegent1Id = 1, WydarzenieId = 2}
            };
            table.AddRange(warsztaty);
        }

        #endregion

    }
}