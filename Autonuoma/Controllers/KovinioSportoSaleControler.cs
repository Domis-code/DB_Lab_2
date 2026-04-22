namespace Lab_2_DB.Controllers;

using Microsoft.AspNetCore.Mvc;
using Lab_2_DB.Models;
using Lab_2_DB.Repositories;


public class KovinioSportoSaleController : ControllerBase
{
    [HttpGet]
    public ActionResult Index()
    {
        return View(KovinioSportoSaleRepo.List());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View(new KovinioSportoSale());
    }

    [HttpPost]
    public ActionResult Create(KovinioSportoSale s)
    {
        if (ModelState.IsValid)
        {
            try
            {
                KovinioSportoSaleRepo.Insert(s);
                return RedirectToAction("Index");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ModelState.AddModelError("KluboPavadinimas", "Klubas tokiu pavadinimu jau egzistuoja.");
            }
        }
        return View(s);
    }

    [HttpGet]
    public ActionResult Edit(string id)
    {
        return View(KovinioSportoSaleRepo.Find(id));
    }

    [HttpPost]
    public ActionResult Edit(string id, KovinioSportoSale s)
    {
        if (ModelState.IsValid)
        {
            try
            {
                KovinioSportoSaleRepo.Update(id, s);
                return RedirectToAction("Index");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ModelState.AddModelError("KluboPavadinimas", "Klubas tokiu pavadinimu jau egzistuoja arba naudojamas.");
            }
        }
        s.OriginalPK = id;
        return View(s);
    }

    [HttpGet]
    public ActionResult Delete(string id)
    {
        return View(KovinioSportoSaleRepo.Find(id));
    }

    [HttpPost]
    public ActionResult DeleteConfirm(string id)
    {
        try
        {
            KovinioSportoSaleRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            return View("Delete", KovinioSportoSaleRepo.Find(id));
        }
    }
}