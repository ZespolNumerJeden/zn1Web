using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace zn1Web.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public int UczestnikId { get; set; }
        private Uczestnik Uczestnik { get; set; }
        
        



    }
}