using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    
    public class EFAlbums : IAlbumsMock
    {
        //connect with DB//
         MusicStoreEntities storeDB = new MusicStoreEntities();
        public IQueryable<Album> Albums { get { return storeDB.Albums; } }

        public void Delete(Album album)
        {
            storeDB.Albums.Remove(album);
            storeDB.SaveChanges();

        }

        // To save album in MusicStoreEntities.
        public Album Save(Album album)
        {
            if (album.AlbumId ==0 )
            {
                //insert//
                storeDB.Albums.Add(album);
            }
            else
            {
                //Update//
                storeDB.Entry(album).State = System.Data.Entity.EntityState.Modified;
            }

            storeDB.SaveChanges();
            return album;
        }
    }
}