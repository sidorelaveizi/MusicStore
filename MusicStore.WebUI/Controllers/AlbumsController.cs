using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;


namespace MusicStore.WebUI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AlbumsController : Controller
    {
        private readonly IUnitOfWork repo;

        public AlbumsController(IUnitOfWork work)
        {
            repo = work;
        }
        // GET: /Albums/
        [Authorize]
        public ActionResult Index() {
            List<AdminViewModel> model = new List<AdminViewModel>();
            model = repo.Albums.GetAlbums(model);             
            return View(model);
        }

        // GET: /Album/Create
        public ActionResult Create()
        {
            var genreList = repo.Albums.GetGenres();
            var artistList = repo.Albums.GetArtist();
            ViewBag.GenreId = new SelectList(genreList, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(artistList, "ArtistId", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Albums.InsertAlbum(album);
                    repo.Save();
                    return RedirectToAction("Index");
                }
                var genreList = repo.Albums.GetGenres();
                var artistList = repo.Albums.GetArtist();

                ViewBag.GenreId = new SelectList(genreList, "GenreId", "Name", album.GenreId);
                ViewBag.ArtistId = new SelectList(artistList, "ArtistId", "Name", album.ArtistId);
                
            }
            catch (DataException)
            {
                
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(album);

        }

        public ActionResult Edit(int id)
        {
            Album album = repo.Albums.GetById(id);
            var genreList = repo.Albums.GetGenres();
            var artistList = repo.Albums.GetArtist();

            ViewBag.GenreId = new SelectList(genreList, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(artistList, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }
     

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Albums.UpdateAlbum(album);
                    repo.Save();
                    return RedirectToAction("Index");
                }

                else
                {
                    return View(album);
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            var genreList = repo.Albums.GetGenres();
            var artistList = repo.Albums.GetArtist();

            ViewBag.GenreId = new SelectList(genreList, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(artistList, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // GET: /Album/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Album album = repo.Albums.GetById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }
        
        // POST: /Album/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
               try
                {
                    Album album = repo.Albums.GetById(id);
                    repo.Albums.DeleteAlbum(id);
                    repo.Save();
                }
                catch (DataException)
                {
                    
                    return RedirectToAction("Delete", new { id = id, saveChangesError = true });
                }
                return RedirectToAction("Index");
          
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    
}
}