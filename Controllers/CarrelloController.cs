using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    public class CarrelloController : Controller
    {
        private const string CarrelloSessionKey = "Carrello";

        public ActionResult Index()
        {
            var carrello = Session[CarrelloSessionKey] as List<Prodotti> ?? new List<Prodotti>();
            return View(carrello);
        }

        [HttpPost]
        public ActionResult AggiungiAlCarrello(int id)
        {
            using (var db = new DbConnection())
            {
                var prodotto = db.Prodotti.FirstOrDefault(p => p.Id == id);
                if (prodotto != null)
                {
                    var carrello = Session[CarrelloSessionKey] as List<Prodotti> ?? new List<Prodotti>();
                    carrello.Add(prodotto);
                    Session[CarrelloSessionKey] = carrello;
                }
            }

            return RedirectToAction("Index", "Pizza");
        }

        [HttpPost]
        public ActionResult RimuoviDalCarrello(int id)
        {
            var carrello = Session[CarrelloSessionKey] as List<Prodotti>;
            if (carrello != null)
            {
                var prodottoDaRimuovere = carrello.FirstOrDefault(p => p.Id == id);
                if (prodottoDaRimuovere != null)
                {
                    carrello.Remove(prodottoDaRimuovere);
                    Session[CarrelloSessionKey] = carrello;
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EffettuaPagamento()
        {
            // Simulazione del pagamento
            Session.Remove(CarrelloSessionKey);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GetCartItemCount()
        {
            var carrello = Session[CarrelloSessionKey] as List<Prodotti>;
            int count = carrello != null ? carrello.Count : 0;
            return Content(count.ToString());
        }
    }
}
