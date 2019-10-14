using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreFinalTests.Fakes
{
    class FakeAlbumDAL : IAlbumDAL
    {

        public int albumId = 5;
        public Album FindById(int? id)
        {
            if (id == albumId)
            {
                return new Album()
                {
                    AlbumId = 5,
                    GenreId = 2,
                    ArtistId = 3,
                    Title = "Man Power",
                    Price = 9,
                    AlbumArtUrl = "/Content/Images/placeholder.gif"
                };
            }
            return null;
        }

        public IQueryable<Album> GetAllAlbums()
        {
            List<Album> albums = new List<Album>();
            albums.Add(new Album()
            {
                AlbumId = 5,
                GenreId = 2,
                ArtistId = 3,
                Title = "Man Power",
                Price = 9,
                AlbumArtUrl = "/Content/Images/placeholder.gif"
            });

            albums.Add(new Album()
            {
                AlbumId = 5,
                GenreId = 8,
                ArtistId = 10,
                Title = "Woman Power",
                Price = 7,
                AlbumArtUrl = "/Content/Images/placeholder.gif"
            });
            return albums.AsQueryable();
        }
    }
}
