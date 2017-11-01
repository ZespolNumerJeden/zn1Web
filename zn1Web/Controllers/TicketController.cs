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
            AuthenticateRequest();

            var bilet = await dbContext.Bilety.Where(b => b.Id == ticketId)
                                              .Include(b => b.Uczestnik)
                                              .Include(b => b.Wydarzenie)
                                              .FirstAsync();

            if (bilet == null)
                return NotFound();
            if (bilet.Uczestnik == null || bilet.Wydarzenie == null)
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent)
                                       {
                                           ReasonPhrase = "Brak danych uczestnika lub wydarzenia."
                                       });

            var td = new TicketData(bilet);
            return Json(td, jsonSettings);

        }

        #endregion

        #region PATCH

        // PATCH: api/Ticket/{ticketId?isPresent}
        public async Task<IHttpActionResult> Patch(Guid ticketId, bool isPresent)
        {
            AuthenticateRequest();

            var bilet = await dbContext.Bilety.Where(b => b.Id == ticketId).Include(b => b.Uczestnik).FirstAsync();

            bilet.ObecnyNaWydarzeniu = isPresent;

            // jeśli już był kiedyś obecny to nie zmieniamy na false
            bilet.Uczestnik.ObecnyKiedykolwiek = bilet.Uczestnik.ObecnyKiedykolwiek || isPresent;
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Authorizes request.
        /// </summary>
        /// <returns>True if authorization OK.</returns>
        private void AuthenticateRequest()
        {

            if (Request.Headers.Contains("apiKey"))
            {
                if (!string.IsNullOrEmpty(Request.Headers.GetValues("apiKey").First()))
                {
                    return;
                }
            }

            // yes, bad response code - needs to halt redirect for 401 code - mvc / web api conflict :(
            var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable) {ReasonPhrase = "Unauthorized. Bad api key."};
            throw new HttpResponseException(msg);
        }

        #endregion

        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};

    }
}
