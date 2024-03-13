using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    public class CarrelloController : Controller
    {
        private readonly List<Prodotti> carrello = new List<Prodotti>();

        public ActionResult Index()
        {
            return View(carrello);
        }

        [HttpPost]
        public ActionResult AggiungiAlCarrello(int id)
        {
            DbConnection db = new DbConnection();
            {
                var prodotto = DbConnection.Prodotti.FirstOrDefault(p => p.Id == id);
                if (prodotto != null)
                {
                    carrello.Add(prodotto);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
