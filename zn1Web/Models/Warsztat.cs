using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int MaxOsob { get; set; }

        public Prelegent Prelegent1 { get; set; }
        public int Prelegent1Id { get; set; }

//        public int Prelegent2 { get; set; }
//        public int Prelegent3 { get; set; }
    }
}