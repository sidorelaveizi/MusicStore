using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Infrastructure;
using MusicStore.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork repo;

        public AccountController(IUnitOfWork work)
        {
            repo = work;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (ModelState.IsValid)
            {
            }
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return View("Error", new string[] { "Access Denied" });
            //}
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(details.Name,details.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid name or password.");
                }
                else
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(details);
        }
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result = await UserManager.CreateAsync(user,
                model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Users");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public ActionResult ChangePassword(ChangePassword model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AppUser user = AppUser.FindByName(HttpContext.User.Identity.Name);
        //        IdentityResult result = UserManager.ChangePassword(user.Id, model.OldPassword, model.NewPassword);
        //        if (result.Succeeded)
        //        {
        //            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
        //            authenticationManager.SignOut();
        //            return RedirectToAction("Login", "Account");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Error while changing the password.");
        //        }
        //    }
        //    return View(model);
        //}
        [Authorize]
        public ActionResult Logout()
        {

            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}