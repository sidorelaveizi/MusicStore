using MusicStore.Domain.Abstract;
using System.Web.Mvc;
namespace MusicStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork repo;
        public int PageSize = 4;

        public HomeController(IUnitOfWork work)
        {
            repo = work;
        }

        public ActionResult Index(string searchString, int? page)
        {
            var albums = repo.Albums.SearchAlbum(searchString, page);
            return View(albums);
        }

       
    }
}