using Pizzeria.Models;
using System.Web.Mvc;
using System.Linq;

public class PizzaController : Controller
{
    private readonly DbConnection db = new DbConnection();

    public ActionResult Index()
    {
        var pizze = db.Prodotti.ToList();
        return View(pizze);
    }

    [Authorize(Roles = "Admin")]
    public ActionResult AggiungiPizza()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    public ActionResult ModificaPizza(int id)
    {
        var pizza = db.Prodotti.FirstOrDefault(p => p.Id == id);
        if (pizza == null)
        {
            return HttpNotFound();
        }
        return View(pizza);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public ActionResult RimuoviPizza(int id)
    {
        var pizza = db.Prodotti.FirstOrDefault(p => p.Id == id);
        if (pizza != null)
        {
            db.Prodotti.Remove(pizza);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public ActionResult SalvaPizza(Prodotti pizza)
    {
        if (ModelState.IsValid)
        {
            if (pizza.Id == 0)
            {
                db.Prodotti.Add(pizza);
            }
            else
            {
                var existingPizza = db.Prodotti.FirstOrDefault(p => p.Id == pizza.Id);
                if (existingPizza != null)
                {
                    existingPizza.Nome = pizza.Nome;
                    existingPizza.Ingredienti = pizza.Ingredienti;
                    existingPizza.Prezzo = pizza.Prezzo;
                    existingPizza.Foto = pizza.Foto;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AggiungiPizza", pizza);
    }
}
