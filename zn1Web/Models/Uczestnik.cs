using System.ComponentModel.DataAnnotations;

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
    }
}