using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models;
using System.Web.Mvc;


namespace MusicStore.WebUI.Controllers
{
    public class StoreController : Controller
    {

        private readonly IUnitOfWork repo;

       public StoreController(IUnitOfWork work)
        {
            repo = work;

        }

        // GET: Genre
        
        public ActionResult Index()
        {
            AlbumViewModels model = new AlbumViewModels();
            model.Genres = repo.Genres.GetAll();
            return View(model);
            

        }
        // GET: Albums/Details/2
        public ActionResult Details(int id)
        {
            Album album = repo.Albums.GetById(id);

            return View(album);
        }

        //test
        public ActionResult Merr(string name)
        {
            var albums = repo.Albums.GetByName(name);
                return View(albums);

        }

        //
        // GET: /Store/Browse
        public ActionResult Browse(int id)
        {

            // Retrieve Genre and its Associated Albums from database
            //var viewModel = new AlbumViewModels()
            //{
            //    Albums = repo.Albums.GetAlbumByGenre(id),
            //};

           var albums = repo.Albums.GetAlbumsByGenre(id);

            
          
          //};
           
           return View(albums);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            AlbumViewModels model = new AlbumViewModels();
            model.Genres = repo.Genres.GetAll();

            return PartialView(model);
        }




    }
}