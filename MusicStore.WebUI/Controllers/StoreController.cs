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
        public ActionResult Details(int id)
        {
            Album album = repo.Albums.GetById(id);

            return View(album);
        }


        public ActionResult Browse(int id)
        {

            // Retrieve Genre and its Associated Albums from database
            //var viewModel = new ViewModels()
            //{
            var albums = repo.Albums.GetAlbumByGenre(id);
          //};
           
            return View(albums);
        }

      

    }
}