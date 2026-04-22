namespace Lab_2_DB.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab_2_DB.Models;
using Lab_2_DB.Repositories;


public class TrenerisController : ControllerBase
{
    private void PopulateLists(Treneris t)
    {
        var sales = KovinioSportoSaleRepo.List();
        t.SportoSalesList = sales.Select(s => new SelectListItem
        {
            Value = s.KluboPavadinimas,
            Text = $"{s.KluboPavadinimas} ({s.Miestas})"
        }).ToList();
    }

    [HttpGet]
    public ActionResult Index()
    {
        return View(TrenerisRepo.List());
    }

    [HttpGet]
    public ActionResult Create()
    {
        var t = new Treneris();
        PopulateLists(t);
        return View(t);
    }

    [HttpPost]
    public ActionResult Create(Treneris t)
    {
        if (ModelState.IsValid)
        {
            TrenerisRepo.Insert(t);
            return RedirectToAction("Index");
        }
        PopulateLists(t);
        return View(t);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var t = TrenerisRepo.Find(id);
        PopulateLists(t);
        return View(t);
    }

    [HttpPost]
    public ActionResult Edit(int id, Treneris t)
    {
        if (ModelState.IsValid)
        {
            t.Id = id;
            TrenerisRepo.Update(t);
            return RedirectToAction("Index");
        }
        PopulateLists(t);
        return View(t);
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        var t = TrenerisRepo.Find(id);
        PopulateLists(t);
        return View(t);
    }

    [HttpPost]
    public ActionResult DeleteConfirm(int id)
    {
        try
        {
            TrenerisRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            var t = TrenerisRepo.Find(id);
            PopulateLists(t);
            return View("Delete", t);
        }
    }
}


