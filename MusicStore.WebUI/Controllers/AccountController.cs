using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork repo;

        public AccountController(IUnitOfWork work)
        {

            repo = work;
        }


        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Index()
        {
            var list = repo.Users.GetAll();
            return View(list);
        }

        //register
        [HttpGet]
        public ActionResult AddOrEdit()
        {
            //User user = new User();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(User user)
        {
            if (ModelState.IsValid)
            {
                repo.Users.Insert(user);
                repo.Save();
                ModelState.Clear();
               
                ViewBag.SuccessMessage = user.UserName + " " + user.Email + "successfully registered";
            }

            //return RedirectToAction("AddressAndPayment", "Checkout");
            return View(user /*"AddOrEdit", new User()*/);
        }


        //
        // GET: /Account/LogIn

     

        public ActionResult LogIn()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User user)
        {

            var usr = repo.Users.SingleOrDefault(u => u.UserName == user.UserName);
            if(user != null)
            {
                Session["UserID"] = user.UserID.ToString();
                Session["UserName"] = user.UserName.ToString();

                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "UserName or Password is Wrong");
            }
            return View();
                  
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }




       
    }
}