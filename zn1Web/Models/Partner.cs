using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace zn1Web.Models
{
    public class Partner
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Nazwa { get; set; }

        [StringLength(500)]
        public string Opis { get; set; }

        [Url]
        [StringLength(200)]
        public string LogoLink { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        #region Seed

        /// <summary>
        /// Seeds table with mock data.
        /// </summary>
        /// <param name="table">Table Partnerzy</param>
        internal static void Seed(DbSet<Partner> table)
        {
            var partnerzy = new List<Partner>
            {
                new Partner {LogoLink = "http://dup1.a/pl", Status = "sadwqdawdas"},
                new Partner {LogoLink = "http://dup2.a/pl", Status = "sadwqdawdzxceas"},
                new Partner {LogoLink = "http://dup3.a/pl", Status = "sadwqda12321wdas"}
            };
            table.AddRange(partnerzy);
        }

        #endregion

    }
}