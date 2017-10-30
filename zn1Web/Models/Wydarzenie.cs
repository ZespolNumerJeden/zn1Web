using System.Collections.Generic;
using System.Data.Entity;

namespace zn1Web.Models
{
    public class Wydarzenie
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        #region Seed

        /// <summary>
        /// Seeds db with mock data.
        /// </summary>
        /// <param name="table">Table Wydarzenia</param>
        internal static void Seed(DbSet<Wydarzenie> table)
        {
            var wydarzenia = new List<Wydarzenie>
            {
                new Wydarzenie {Nazwa = "Konferencja Ogarnij Agile 1"},
                new Wydarzenie {Nazwa = "Konferencja Ogarnij Agile 2"},
                new Wydarzenie {Nazwa = "Warsztaty Scrum 1"},
                new Wydarzenie {Nazwa = "Warsztaty Agile 1"}
            };
            table.AddRange(wydarzenia);
        }

        #endregion
    }
}