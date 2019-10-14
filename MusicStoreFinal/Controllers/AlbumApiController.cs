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
    public class AlbumApiController : ApiController
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: api/AlbumApi
        public IQueryable<Album> GetAlbums()
        {
            return storeDB.Albums;
        }

        // GET: api/AlbumApi/5
        [ResponseType(typeof(Album))]
        public IHttpActionResult GetAlbum(int id)
        {
            Album album = storeDB.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // PUT: api/AlbumApi/5
        [ResponseType(typeof(void))]
        [BasicAuthentication]
        public IHttpActionResult PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.AlbumId)
            {
                return BadRequest();
            }

            storeDB.Entry(album).State = EntityState.Modified;

            try
            {
                storeDB.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/AlbumApi
        [ResponseType(typeof(Album))]
        [BasicAuthentication]
        public IHttpActionResult PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            storeDB.Albums.Add(album);
            storeDB.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = album.AlbumId }, album);
        }

        // DELETE: api/AlbumApi/5
        [ResponseType(typeof(Album))]
        [BasicAuthentication]
        public IHttpActionResult DeleteAlbum(int id)
        {
            Album album = storeDB.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }

            storeDB.Albums.Remove(album);
            storeDB.SaveChanges();

            return Ok(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                storeDB.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlbumExists(int id)
        {
            return storeDB.Albums.Count(e => e.AlbumId == id) > 0;
        }
    }
}