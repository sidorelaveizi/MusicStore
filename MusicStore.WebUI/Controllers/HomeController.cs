using MusicStore.Domain.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork repo;

        public HomeController(IUnitOfWork work)
        {
            repo = work;
        }


        public ActionResult Index()
        {
            var albums = repo.Albums.GetAll().ToList();

            return View(albums);
        }


       
    }
}