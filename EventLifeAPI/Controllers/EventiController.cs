using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EL_Repository;

namespace EventLifeAPI.Controllers
{
    public class EventiController : ApiController
    {
        private event_lifeEntities db = new event_lifeEntities();

        // GET api/Eventi
        public IEnumerable<Eventi> GetEventis()
        {
            var eventis = db.Eventis.Include(e => e.Categoria).Include(e => e.Gallery).Include(e => e.Profilo);
            return eventis.AsEnumerable();
        }

        // GET api/Eventi/5
        public Eventi GetEventi(int id)
        {
            Eventi eventi = db.Eventis.Find(id);
            if (eventi == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return eventi;
        }        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}