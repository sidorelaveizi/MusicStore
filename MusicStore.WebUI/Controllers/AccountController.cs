using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Identity;
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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl, bool isAdmin = false)
        {
            if (ModelState.IsValid)
            {
                // Clear the existing external cookie to ensure a clean login process

                if (HttpContext.User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
                {
                    return RedirectToAction("Index", "Albums");

                }
                ViewBag.isAdmin = false;

                if (isAdmin)
                {
                    ViewBag.isAdmin = isAdmin;

                }

                ViewBag.returnUrl = returnUrl;
                return View();
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(details.Name, details.Password);
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
                        //IsPersistent = false
                        IsPersistent = details.RememberMe
                    }, ident);
                    if (User.IsInRole("Administrator") && User.Identity.IsAuthenticated)
                    {
                        return RedirectToAction("Index", "Albums");
                    }
                    else
                    {
                        if (User.Identity.IsAuthenticated && User.IsInRole("User"))
                        {
                            return RedirectToAction("CheckoutDetails", "Checkout");
                        }
                        return RedirectToAction("Index", "Home");

                    }

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
                    UserManager.AddToRole(user.Id, "User");
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
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}