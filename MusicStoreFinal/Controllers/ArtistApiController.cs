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
    public class ArtistApiController : ApiController
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: api/ArtistApi
        public IQueryable<Artist> GetArtists()
        {
            return storeDB.Artists;
        }

        // GET: api/ArtistApi/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult GetArtist(int id)
        {
            Artist artist = storeDB.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/ArtistApi/5
        [ResponseType(typeof(void))]
        [BasicAuthentication]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            storeDB.Entry(artist).State = EntityState.Modified;

            try
            {
                storeDB.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/ArtistApi
        [ResponseType(typeof(Artist))]
        [BasicAuthentication]
        public IHttpActionResult PostArtist(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            storeDB.Artists.Add(artist);
            storeDB.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = artist.ArtistId }, artist);
        }

        // DELETE: api/ArtistApi/5
        [ResponseType(typeof(Artist))]
        [BasicAuthentication]
        public IHttpActionResult DeleteArtist(int id)
        {
            Artist artist = storeDB.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }

            storeDB.Artists.Remove(artist);
            storeDB.SaveChanges();

            return Ok(artist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                storeDB.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return storeDB.Artists.Count(e => e.ArtistId == id) > 0;
        }
    }
}