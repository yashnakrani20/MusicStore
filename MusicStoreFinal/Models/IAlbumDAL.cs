using System.Linq;

namespace MusicStore.Models
{
    public interface IAlbumDAL
    {
        Album FindById(int? id);
        IQueryable<Album> GetAllAlbums();
    }
}