using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    public class UtentiController : Controller
    {
        DbConnection db = new DbConnection();

        [Authorize(Roles = "Admin")]
        public ActionResult AdminPage()
        {
            var user = User;
            var users = db.Users.ToList();
            return View(users);
        }

        [Authorize(Roles = "User")]
        public ActionResult UsersPage()
        {
            var user = User;
            var users = db.Users.ToList();
            return View(users);
        }
    }
}