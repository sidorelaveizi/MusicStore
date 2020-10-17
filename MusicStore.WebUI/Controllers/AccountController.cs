using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Concrete;
using MusicStore.Domain.Infrastructure;
using MusicStore.WebUI.Models;
using System.Linq;
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
        ApplicationDbContext _context = new ApplicationDbContext();

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

        public ActionResult Register()
        {
            //ViewBag.Name = new SelectList(_context.Roles.Where(u => !u.Name.Contains("Admin"))
            //                             .ToList(), "Name", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               
               AppUser user = new AppUser() { UserName = model.UserName, Email = model.Email };
               var result = await UserManager.CreateAsync(user, model.Password);

                 if (result.Succeeded)
                {
                 
                    UserManager.AddToRole(user.Id, model.UserRoles);
                    return RedirectToAction("Login", "Account");
                }
               
                else
                {
                    ViewBag.Name = new SelectList(_context.Roles.Where(u => !u.Name.Contains("Admin"))
                               .ToList(), "Name", "Name");
                    ModelState.AddModelError("UserName", "Error while creating the user!");
                }


                //AppUser user = new AppUser();

                //user.UserName = model.UserName;
                //user.Email = model.Email;
                //user.PasswordHash = model.Password;

                //IdentityResult result = userManager.Create(user, model.Password);

                //if (result.Succeeded)
                //{
                //    userManager.AddToRole(user.Id, "Administrator");
                //    return RedirectToAction("Login", "Account");
                //}
                //else
                //{
                //    ModelState.AddModelError("UserName", "Error while creating the user!");
                //}

            }
            return View(model);
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
    }
}