using System;
using zn1Web.Models;

namespace zn1Web.Controllers
{

    /// <summary>
    /// Represents ticket data returned in http responses.
    /// </summary>
    [Serializable]
    public class TicketData
    {

        /// <summary>
        /// Default ctor.
        /// </summary>
        /// <param name="bilet">Bilet entry.</param>
        public TicketData(Bilet bilet)
        {
            Id = bilet.Id;
            FirstName = bilet.Uczestnik.Imie;
            LastName = bilet.Uczestnik.Nazwisko;
            CompanyName = bilet.Uczestnik.Firma;
            IsPresent = bilet.ObecnyNaWydarzeniu;
            WasInPast = bilet.Uczestnik.ObecnyKiedykolwiek;
            EventName = bilet.Wydarzenie?.Nazwa;
            EventDate = bilet.Wydarzenie?.DataWydarzenia.ToLocalTime().ToShortDateString();
            EventTime = bilet.Wydarzenie?.DataWydarzenia.ToLocalTime().ToShortTimeString();
        }

        /// <summary>Guid of ticket.</summary>
        /// <remarks>Used to generate QR code.</remarks>
        public Guid Id { get; set; }

        // from Uczestnik table
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public bool WasInPast { get; set; }

        // from Wydarzenie table
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public bool IsPresent { get; set; }

    }

}