using System;
using System.Collections;
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
    public class CategorieController : ApiController
    {
        private event_lifeEntities db = new event_lifeEntities();

        // GET api/Categorie        
        public IEnumerable<Categoria> GetCategorias()
        {                        
            return db.Categorias.AsEnumerable();
        }

        // GET api/Categorie/5
        public Categoria GetCategoria(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return categoria;
        }        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }        
}