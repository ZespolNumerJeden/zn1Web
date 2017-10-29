using System.ComponentModel.DataAnnotations;

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

        // Prelegent 1
        public Prelegent Prelegent1 { get; set; }
        public int? Prelegent1Id { get; set; }

        // Prelegent 2
        public Prelegent Prelegent2 { get; set; }
        public int? Prelegent2Id { get; set; }

        // Prelegent 3
        public Prelegent Prelegent3 { get; set; }
        public int? Prelegent3Id { get; set; }

    }
}