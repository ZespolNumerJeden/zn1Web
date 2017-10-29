namespace zn1Web.Models
{
    public class Bilet
    {

        public int Id { get; set; }

        public Uczestnik Uczestnik { get; set; }
        public int UczestnikId { get; set; }

        public ListaObecnosci Obecnosc { get; set; }
        public int ObecnoscId { get; set; }


    }
}