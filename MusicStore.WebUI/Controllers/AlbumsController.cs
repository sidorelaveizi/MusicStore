using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class AlbumsController : Controller
    {
        IUnitOfWork repo;

        public AlbumsController(IUnitOfWork work)
        {
            repo = work;
        }
        

        // GET: /Albums/
        public ViewResult Index()
        {
            var albums = repo.Albums.GetAll();
            return View(albums.ToList());
        }

        // GET: /Albums/Details/5
        public ViewResult Details(int id)
        {
            Album album = repo.Albums.GetById(id);
            return View(album);
        }

        // GET: /Album/Create
        public ActionResult Create()
        {
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
                    repo.Albums.Insert(album);
                    repo.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(album);
        }

        public ActionResult Edit(int id)
        {
            Album album = repo.Albums.GetById(id);
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(

           Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Albums.Update(album);
                    repo.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(album);
        }

        // GET: /Album/Delete/5
        public ActionResult Delete(int id)
        {
            Album album = repo.Albums.GetById(id);
            return View(album);
        }

        // POST: /Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = repo.Albums.GetById(id);
            repo.Albums.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    
}
}