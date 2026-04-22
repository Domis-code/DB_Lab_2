namespace Lab_2_DB.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab_2_DB.Models;
using Lab_2_DB.Repositories;


public class KovosTaisyklesController : ControllerBase
{
    private void PopulateLists(KovosTaisykles k)
    {
        k.TaisykliuTipaiList = LookUpLentelesRepo.ListKovosTaisykliuTipai()
            .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
            .ToList();

        k.TaskuSistemaList = LookUpLentelesRepo.ListTaskuSistema()
            .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
            .ToList();
    }

    [HttpGet]
    public ActionResult Index()
    {
        return View(KovosTaisyklesRepo.List());
    }

    [HttpGet]
    public ActionResult Create()
    {
        var k = new KovosTaisykles();
        PopulateLists(k);
        return View(k);
    }

    [HttpPost]
    public ActionResult Create(KovosTaisykles k)
    {
        if (ModelState.IsValid)
        {
            try
            {
                KovosTaisyklesRepo.Insert(k);
                return RedirectToAction("Index");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ModelState.AddModelError("TaisykliuPavadinimas", "Taisyklės tokiu pavadinimu jau egzistuoja.");
            }
        }
        PopulateLists(k);
        return View(k);
    }

    [HttpGet]
    public ActionResult Edit(string id)
    {
        var k = KovosTaisyklesRepo.Find(id);
        PopulateLists(k);
        return View(k);
    }

    [HttpPost]
    public ActionResult Edit(string id, KovosTaisykles k)
    {
        if (ModelState.IsValid)
        {
            try
            {
                KovosTaisyklesRepo.Update(id, k);
                return RedirectToAction("Index");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ModelState.AddModelError("TaisykliuPavadinimas", "Taisyklės tokiu pavadinimu jau egzistuoja arba naudojamos.");
            }
        }
        k.OriginalPK = id;
        PopulateLists(k);
        return View(k);
    }

    [HttpGet]
    public ActionResult Delete(string id)
    {
        var k = KovosTaisyklesRepo.Find(id);
        PopulateLists(k);
        return View(k);
    }

    [HttpPost]
    public ActionResult DeleteConfirm(string id)
    {
        try
        {
            KovosTaisyklesRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            var k = KovosTaisyklesRepo.Find(id);
            PopulateLists(k);
            return View("Delete", k);
        }
    }
}