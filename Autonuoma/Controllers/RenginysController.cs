namespace Lab_2_DB.Controllers;
 
using Microsoft.AspNetCore.Mvc;
using Lab_2_DB.Models;
using Lab_2_DB.Repositories;
 
 
public class RenginysController : ControllerBase
{
    [HttpGet]
    public ActionResult Index()
    {
        return View(RenginysRepo.List());
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View(new Renginys { RenginioData = DateTime.Now });
    }

    [HttpPost]
    public ActionResult Create(Renginys r)
    {
        if (ModelState.IsValid)
        {
            try
            {
                RenginysRepo.Insert(r);
                return RedirectToAction("Index");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ModelState.AddModelError("RenginioPavadinimas", "Renginys tokiu pavadinimu jau egzistuoja.");
            }
        }
        return View(r);
    }

    [HttpGet]
    public ActionResult Edit(string id)
    {
        return View(RenginysRepo.Find(id));
    }

    [HttpPost]
    public ActionResult Edit(string id, Renginys r)
    {
        if (ModelState.IsValid)
        {
            try
            {
                RenginysRepo.Update(id, r);
                return RedirectToAction("Index");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ModelState.AddModelError("RenginioPavadinimas", "Renginys tokiu pavadinimu jau egzistuoja arba naudojamas.");
            }
        }
        r.OriginalPK = id;
        return View(r);
    }

    [HttpGet]
    public ActionResult Delete(string id)
    {
        return View(RenginysRepo.Find(id));
    }

    [HttpPost]
    public ActionResult DeleteConfirm(string id)
    {
        try
        {
            RenginysRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            return View("Delete", RenginysRepo.Find(id));
        }
    }
}



