using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcmusicStore.Models;
using System.Data.Entity;
using System.Net;

namespace MvcmusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();
        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);

            return View(albums.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.FirstOrDefault(a => a.AlbumId == id.Value);
            if (album == null) 
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists.ToList(), "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        [HttpPost]
        public ActionResult Edit (Models.Album album)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}