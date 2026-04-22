namespace Lab_2_DB.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab_2_DB.Models;
using Lab_2_DB.Repositories;


public class SvorioKategorijaController : ControllerBase
{
    private void PopulateLists(SvorioKategorija k)
    {
        k.LytisList = LookUpLentelesRepo.ListLytis()
            .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
            .ToList();
    }

    [HttpGet]
    public ActionResult Index()
    {
        return View(SvorioKategorijaRepo.List());
    }

    [HttpGet]
    public ActionResult Create()
    {
        var k = new SvorioKategorija();
        PopulateLists(k);
        return View(k);
    }

    [HttpPost]
    public ActionResult Create(SvorioKategorija k)
    {
        if (k.MaxKg < k.MinKg)
            ModelState.AddModelError("MaxKg", "Maks. svoris negali būti mažesnis už min. svorį.");

        if (ModelState.IsValid)
        {
            SvorioKategorijaRepo.Insert(k);
            return RedirectToAction("Index");
        }
        PopulateLists(k);
        return View(k);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var k = SvorioKategorijaRepo.Find(id);
        PopulateLists(k);
        return View(k);
    }

    [HttpPost]
    public ActionResult Edit(int id, SvorioKategorija k)
    {
        if (k.MaxKg < k.MinKg)
            ModelState.AddModelError("MaxKg", "Maks. svoris negali būti mažesnis už min. svorį.");

        if (ModelState.IsValid)
        {
            k.Id = id;
            SvorioKategorijaRepo.Update(k);
            return RedirectToAction("Index");
        }
        PopulateLists(k);
        return View(k);
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        var k = SvorioKategorijaRepo.Find(id);
        PopulateLists(k);
        return View(k);
    }

    [HttpPost]
    public ActionResult DeleteConfirm(int id)
    {
        try
        {
            SvorioKategorijaRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            var k = SvorioKategorijaRepo.Find(id);
            PopulateLists(k);
            return View("Delete", k);
        }
    }
}


