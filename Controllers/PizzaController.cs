using System.Linq;
using System.Web.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        private readonly DbConnection db = new DbConnection();

        public ActionResult Index()
        {
            var pizze = db.Prodotti.ToList();
            return View(pizze);
        }
    }
}
