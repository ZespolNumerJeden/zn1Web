using System.ComponentModel.DataAnnotations;

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
    }
}