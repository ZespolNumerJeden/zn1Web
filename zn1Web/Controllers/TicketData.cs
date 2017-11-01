using System;

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
        /// <param name="id"></param>
        public TicketData(Guid id)
        {
            Id = id;
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