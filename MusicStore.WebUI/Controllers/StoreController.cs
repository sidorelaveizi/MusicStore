using MusicStore.Domain.Abstract;
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

        public ActionResult Index()
        {
            AlbumViewModels model = new AlbumViewModels();
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
            //Retrieve Genre and its Associated Albums from database
           var viewModel = new AlbumViewModels()
           {
               Album = repo.Albums.GetAlbumsByGenre(id),
           };
           
           return View(viewModel);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu(bool horizontalLayout = false)
        {
            AlbumViewModels model = new AlbumViewModels();
            model.Genres = repo.Genres.GetAll();
           // string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return PartialView(model);
        }




    }
}