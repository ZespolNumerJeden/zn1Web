using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace zn1Web.Models
{
    public class Prelegent
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Imie { get; set; }

        [StringLength(50)]
        public string Nazwisko { get; set; }

        [StringLength(20)]
        public string TytNaukowy { get; set; }

        [StringLength(500)]
        public string Bio { get; set; }

        [Url]
        [StringLength(200)]
        public string FotoLink { get; set; }

        #region Seed

        /// <summary>
        /// Seeds table with mock Prelegent.
        /// </summary>
        /// <param name="table">Prelegenci table.</param>
        internal static void Seed(DbSet<Prelegent> table)
        {
            var prelegenci = new List<Prelegent>
            {
                new Prelegent {Imie = "P1", Nazwisko = "P1", FotoLink = "http://dup.a/pl"},
                new Prelegent {Imie = "P2", Nazwisko = "P2", FotoLink = "http://dup.a/pl"},
                new Prelegent {Imie = "P3", Nazwisko = "P3", FotoLink = "http://dup.a/pl"},
                new Prelegent {Imie = "P4", Nazwisko = "P4", FotoLink = "http://dup.a/pl"},
                new Prelegent {Imie = "P5", Nazwisko = "P5", FotoLink = "http://dup.a/pl"},
                new Prelegent {Imie = "P6", Nazwisko = "P6", FotoLink = "http://dup.a/pl"}
            };
            table.AddRange(prelegenci);
        }

        #endregion

    }
}