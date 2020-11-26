using MusicStore.Domain.Abstract;
using MusicStore.Domain.Models;
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
        public ActionResult Index()
        {
            AlbumViewModels model = new AlbumViewModels();
            model.Albums = repo.Albums.GetAll();
            model.Genres = repo.Genres.GetAll();
            return View(model);
            

        }
        // GET: Albums/Details/
        public ActionResult Details(int id)
        {
           var model = repo.Albums.GetAlbumDetails(id);
            return View(model);
        }

        //
        // GET: /Store/Browse
        public ActionResult Browse(int id)
        {
            //Retrieve Genre and its Associated Albums
            var viewModel = new AlbumViewModels()
           {
               Albums = repo.Albums.GetAlbumsByGenre(id),
               GenreName = repo.Albums.GetGenreById(id).Name
           };
           
           return View(viewModel);
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