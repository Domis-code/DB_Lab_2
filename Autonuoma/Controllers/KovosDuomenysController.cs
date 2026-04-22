namespace Lab_2_DB.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab_2_DB.Models;
using Lab_2_DB.Repositories;

public class KovosDuomenysController : ControllerBase
{
    private void PopulateLists(KovosDuomenys k)
    {
        k.KovosStatusasList = KovosDuomenysRepo.ListKovosStatusas()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();

        k.SvorioKategorijaList = KovosDuomenysRepo.ListSvorioKategorija()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.KategorijosPavadinimas })
            .ToList();

        k.RenginysList = KovosDuomenysRepo.ListRenginiai()
            .Select(x => new SelectListItem { Value = x.RenginioPavadinimas, Text = x.RenginioPavadinimas })
            .ToList();

        k.KovosTaisyklesList = KovosDuomenysRepo.ListKovosTaisykles()
            .Select(x => new SelectListItem { Value = x.TaisykliuPavadinimas, Text = x.TaisykliuPavadinimas })
            .ToList();
    }

    [HttpGet]
    public ActionResult Index()
    {
        return View(KovosDuomenysRepo.List());
    }

    [HttpGet]
    public ActionResult Create()
    {
        var k = new KovosDuomenys { KovosLaikasData = DateTime.Now };
        PopulateLists(k);
        return View(k);
    }

    [HttpPost]
    public ActionResult Create(KovosDuomenys k)
    {
        if (ModelState.IsValid)
        {
            KovosDuomenysRepo.Insert(k);
            return RedirectToAction("Index");
        }
        PopulateLists(k);
        return View(k);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var k = KovosDuomenysRepo.Find(id);
        PopulateLists(k);
        return View(k);
    }

    [HttpPost]
    public ActionResult Edit(int id, KovosDuomenys k)
    {
        if (ModelState.IsValid)
        {
            k.Id = id;
            KovosDuomenysRepo.Update(k);
            return RedirectToAction("Index");
        }
        PopulateLists(k);
        return View(k);
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        return View(KovosDuomenysRepo.Find(id));
    }

    [HttpPost]
    public ActionResult DeleteConfirm(int id)
    {
        try
        {
            KovosDuomenysRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            return View("Delete", KovosDuomenysRepo.Find(id));
        }
    }
}



