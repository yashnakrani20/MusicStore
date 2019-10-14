using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    [RequireHttps]
    [Route("home/{action=index}")]
    public class HomeController : Controller
    {

        MusicStoreEntities storeDB = new MusicStoreEntities();

        [Route("")]
        [Route("home")]
        [Route("home/index")]
        public ActionResult Index()
        {
            return View();
        }
        // action to view message and title
        public ActionResult About()
        {
            //ViewBag.Title = "Welcome Our Music Store Web site!";
            ViewBag.Message = "We are a world renowned Music Store with latest Music";

            return View();
        }
        // action to view message and title
        public ActionResult Contact() 
        {
            ViewBag.Title = "This is our Contact Page.";
            ViewBag.Message = "If you have any problem, don't hesitate. Please contact us.";

            return View();
        }
        //for music search through search bar
        [Route("MusicSearch")]
        public ActionResult MusicSearch(string q)
        {
            var musics = GetMusic(q);
            return PartialView(musics);
        }

        [Route("MusicSearch")]
        private List<Album> GetMusic(string searchString)
        {
            return storeDB.Albums.Where(a => a.Title.Contains(searchString)).ToList();
        }
    }
}