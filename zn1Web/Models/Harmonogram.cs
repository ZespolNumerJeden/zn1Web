using System;

namespace zn1Web.Models
{
    public class Harmonogram
    {
        public int Id { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public Warsztat Warsztat { get; set; }
        public Partner Partner { get; set; }
    }
}