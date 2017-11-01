using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace zn1Web.Controllers
{
    public class TicketController : ApiController
    {

        #region GET

        // GET: api/Ticket
        public IHttpActionResult Get()
        {
            return BadRequest("Provide ticketId in GET request.");
        }

        // GET: api/Ticket/{ticketId}
        public async Task<IHttpActionResult> Get(Guid ticketId)
        {

            if (!AuthenticateRequest())
            {
                // yes, bad response code - needs to halt redirect for 401 code - mvc / web api conflict :(
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable) {ReasonPhrase = "Unauthorized. Bad api key."};
                throw new HttpResponseException(msg);
            }

            var bilet = await dbContext.Bilety.Where(b => b.Id == ticketId)
                                              .Include(b => b.Uczestnik)
                                              .Include(b => b.Wydarzenie)
                                              .FirstAsync();

            if (bilet == null)
                return NotFound();
            if (bilet.Uczestnik == null || bilet.Wydarzenie == null)
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent){ ReasonPhrase = "Brak danych uczestnika lub wydarzenia." });

            var td = new TicketData(ticketId)
                     {
                         FirstName = bilet.Uczestnik.Imie,
                         LastName = bilet.Uczestnik.Nazwisko,
                         CompanyName = bilet.Uczestnik.Firma,
                         IsPresent = bilet.ObecnyNaWydarzeniu,
                         WasInPast = bilet.Uczestnik.ObecnyKiedykolwiek,
                         EventName = bilet.Wydarzenie.Nazwa,
                         EventDate = bilet.Wydarzenie.DataWydarzenia.ToLocalTime().ToShortDateString(),
                         EventTime = bilet.Wydarzenie.DataWydarzenia.ToLocalTime().ToShortTimeString()
                     };

            var jsonSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};
            return Json(td, jsonSettings);

        }

        #endregion

        #region Helpers

        /// <summary>
        /// Authorizes request.
        /// </summary>
        /// <returns>True if authorization OK.</returns>
        private bool AuthenticateRequest()
        {

            if (Request.Headers.Contains("apiKey"))
            {
                return !string.IsNullOrEmpty(Request.Headers.GetValues("apiKey").First());
            }

            return false;

        }

        #endregion

        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

    }
}
