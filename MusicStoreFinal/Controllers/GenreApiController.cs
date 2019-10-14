using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class GenreApiController : ApiController
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: api/GenreApi
        public IQueryable<Genre> GetGenres()
        {
            return storeDB.Genres;
        }

        // GET: api/GenreApi/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenre(int id)
        {
            Genre genre = storeDB.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        // PUT: api/GenreApi/5
        [ResponseType(typeof(void))]
        [BasicAuthentication]
        public IHttpActionResult PutGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.GenreId)
            {
                return BadRequest();
            }

            storeDB.Entry(genre).State = EntityState.Modified;

            try
            {
                storeDB.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/GenreApi
        [ResponseType(typeof(Genre))]
        [BasicAuthentication]
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            storeDB.Genres.Add(genre);
            storeDB.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = genre.GenreId }, genre);
        }

        // DELETE: api/GenreApi/5
        [ResponseType(typeof(Genre))]
        [BasicAuthentication]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = storeDB.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            storeDB.Genres.Remove(genre);
            storeDB.SaveChanges();

            return Ok(genre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                storeDB.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenreExists(int id)
        {
            return storeDB.Genres.Count(e => e.GenreId == id) > 0;
        }
    }
}