using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using Newtonsoft.Json;
using zn1Web;
using zn1Web.Models;

namespace zn1Web.Controllers
{
    public class ListaObecnosciController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ListaObecnosci
        public IQueryable<ListaObecnosci> GetListyObecnosci()
        {
            return db.ListyObecnosci;
        }

        //GET: api/ListaObecnosci/5
        [ResponseType(typeof(ListaObecnosci))]
        public async Task<IHttpActionResult> GetListaObecnosci(int id)
        {
            ListaObecnosci listaObecnosci = await db.ListyObecnosci.FindAsync(id);
            if (listaObecnosci == null)
            {
                return NotFound();
            }

            return Ok(listaObecnosci);
        }


//        [System.Web.Http.HttpGet]
//        public async Task<JsonResult<ListaObecnosci>> GetListaObecnosci(int id)
//        {
//            
//            ListaObecnosci listaObecnosci = await db.ListyObecnosci.FindAsync(id);
//            if (listaObecnosci == null)
//            {
//                return null;
//            }
//
//            JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
//
//            return new JsonResult<ListaObecnosci>(listaObecnosci, jsonSettings, Encoding.UTF8, new HttpRequestMessage());
//
//        }


        // PUT: api/ListaObecnosci/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutListaObecnosci(int id, ListaObecnosci listaObecnosci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listaObecnosci.Id)
            {
                return BadRequest();
            }

            db.Entry(listaObecnosci).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaObecnosciExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ListaObecnosci
        [ResponseType(typeof(ListaObecnosci))]
        public async Task<IHttpActionResult> PostListaObecnosci(ListaObecnosci listaObecnosci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListyObecnosci.Add(listaObecnosci);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = listaObecnosci.Id }, listaObecnosci);
        }

        // DELETE: api/ListaObecnosci/5
        [ResponseType(typeof(ListaObecnosci))]
        public async Task<IHttpActionResult> DeleteListaObecnosci(int id)
        {
            ListaObecnosci listaObecnosci = await db.ListyObecnosci.FindAsync(id);
            if (listaObecnosci == null)
            {
                return NotFound();
            }

            db.ListyObecnosci.Remove(listaObecnosci);
            await db.SaveChangesAsync();

            return Ok(listaObecnosci);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListaObecnosciExists(int id)
        {
            return db.ListyObecnosci.Count(e => e.Id == id) > 0;
        }
    }
}