using MusicStore.Domain.Abstract;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlbumRepository repository;

        public HomeController(IAlbumRepository albumRepository)
        {
            repository = albumRepository;
        }
        public ViewResult List()
        {
            return View(repository.Albums);
        }
    }
}