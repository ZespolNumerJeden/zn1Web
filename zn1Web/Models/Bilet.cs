using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace zn1Web.Models
{
    public class Bilet
    {
        public Guid Id { get; set; }

        public int UczestnikId { get; set; }
        public Uczestnik Uczestnik { get; set; }

        public int WydarzenieId { get; set; }
        public Wydarzenie Wydarzenie { get; set; }

        public bool ObecnyNaWydarzeniu { get; set; }

        public bool PotwPlatnosci { get; set; }
        public bool PotwObecnosci { get; set; }

        [StringLength(20)]
        public string Obiad { get; set; }

        #region Seed

        internal static void Seed(DbSet<Bilet> table)
        {
            var tickets = new List<Bilet>
                          {
                              new Bilet
                              {
                                  Id = Guid.Parse("b18a464d-f0d3-428f-8774-1aba6ad02745"),
                                  UczestnikId = 1,
                                  WydarzenieId = 2,
                                  PotwPlatnosci = true,
                                  Obiad = "golonka w piwie"
                              },
                              new Bilet
                              {
                                  Id = Guid.Parse("97036ce9-3e81-4b89-abed-2d7673b06679"),
                                  UczestnikId = 2,
                                  WydarzenieId = 2,
                                  PotwPlatnosci = false,
                                  Obiad = "bez glutenu proszę"
                              },
                              new Bilet
                              {
                                  Id = Guid.Parse("f0f37ab1-89a0-48df-a647-4ef9f22efa14"),
                                  UczestnikId = 3,
                                  WydarzenieId = 2,
                                  PotwPlatnosci = false,
                                  Obiad = "będzie?"
                              },
                              new Bilet
                              {
                                  Id = Guid.Parse("2214b920-5869-42b6-9c00-9753a55d57f3"),
                                  UczestnikId = 4,
                                  WydarzenieId = 2,
                                  PotwPlatnosci = true,
                                  Obiad = "normalny"
                              }
                          };

            table.AddRange(tickets);

        }

        #endregion

    }
}