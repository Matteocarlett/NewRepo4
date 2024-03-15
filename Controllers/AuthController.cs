using Pizzeria.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Pizzeria.Controllers
{
    public class AuthController : Controller
    {
        DbConnection db = new DbConnection();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users user)
        {
            var loggedUser = db.Users.FirstOrDefault(u => u.Nome == user.Nome && u.Password == user.Password);
            if (loggedUser == null)
            {
                TempData["ErrorLogin"] = true;
                return RedirectToAction("Login");
            }

            if (loggedUser.Ruolo == "Admin")
            {
                FormsAuthentication.SetAuthCookie(loggedUser.Id.ToString(), true);
                return RedirectToAction("AdminPage", "Utenti");
            }
            else if (loggedUser.Ruolo == "Ospite")
            {
                FormsAuthentication.SetAuthCookie(loggedUser.Id.ToString(), true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email già registrata.");
                    return View(model);
                }

                var newUser = new Users
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Password = model.Password,
                    Ruolo = "Ospite" 
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                TempData["RegistrationSuccess"] = true;
                return RedirectToAction("Login");
            }

            return View(model);
        }

    }
}
