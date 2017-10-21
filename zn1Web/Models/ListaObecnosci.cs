using System;

namespace zn1Web.Models
{
    public class ListaObecnosci
    {
        public int Id { get; set; }
        public Uczestnik Uczestnik { get; set; }
        public Warsztat Warsztat { get; set; }
        public DateTime Rejestracja { get; set; }
        public bool Obecnosc { get; set; }
    }
}