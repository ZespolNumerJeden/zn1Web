using System.ComponentModel.DataAnnotations;

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
    }
}