using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace zn1Web.Models
{
    public class Wydarzenie
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataWydarzenia { get; set; }

        public ICollection<Bilet> Bilety { get; set; }

        #region Seed

        /// <summary>
        /// Seeds db with mock data.
        /// </summary>
        /// <param name="table">Table Wydarzenia</param>
        internal static void Seed(DbSet<Wydarzenie> table)
        {
            var wydarzenia = new List<Wydarzenie>
            {
                new Wydarzenie
                {
                    Nazwa = "Konferencja Ogarnij Agile 1",
                    DataWydarzenia = new DateTime(2016, 05, 21, 6, 00, 00, DateTimeKind.Utc)
                },
                new Wydarzenie
                {
                    Nazwa = "Konferencja Ogarnij Agile 2",
                    DataWydarzenia = new DateTime(2017, 05, 27, 6, 00, 00, DateTimeKind.Utc)
                },
                new Wydarzenie
                {
                    Nazwa = "Warsztaty Scrum 1",
                    DataWydarzenia = new DateTime(2016, 03, 21, 17, 00, 00, DateTimeKind.Utc)
                },
                new Wydarzenie
                {
                    Nazwa = "Warsztaty Agile 1",
                    DataWydarzenia = new DateTime(2017, 01, 21, 18, 00, 00, DateTimeKind.Utc)
                }
            };
            table.AddRange(wydarzenia);
        }

        #endregion
    }
}