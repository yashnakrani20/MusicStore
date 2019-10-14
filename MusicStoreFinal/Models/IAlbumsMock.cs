using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    //To save or Delete albums
    public interface IAlbumsMock
    {
        IQueryable<Album> Albums { get;  }
        Album Save(Album album);
        void Delete(Album album);
    }
}
