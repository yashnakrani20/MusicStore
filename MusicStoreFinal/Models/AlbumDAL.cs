using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;

namespace MusicStore.Models
{
    public class AlbumDAL : IAlbumDAL
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public IQueryable<Album> GetAllAlbums()
        {
            return storeDB.Albums.Include(a => a.Artist).Include(a => a.Genre);
        }

        public Album FindById(int? id)
        {
            return storeDB.Albums.Find(id);
        }
    }
}