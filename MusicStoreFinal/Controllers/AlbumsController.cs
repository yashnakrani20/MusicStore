using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    [RequireHttps]
    public class AlbumsController : Controller
    {
        object @object;

        public AlbumsController(object @object)
        {
            this.@object = @object;
        }

        IAlbumDAL DAL;
        public AlbumsController(IAlbumDAL DAL)
        {
            this.DAL = DAL;
        }

        public AlbumsController()
        {
            this.DAL = new AlbumDAL();
        }

        //AlbumDAL DAL = new AlbumDAL();
        // GET: Albums
        public ActionResult Index()
        {
            var albums = DAL.GetAllAlbums();
            return View(albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }
            Album album = DAL.FindById(id);
            if (album == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View(album);
        }


    }
}