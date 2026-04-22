namespace Lab_2_DB.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab_2_DB.Models;
using Lab_2_DB.Repositories;

public class KovotojoSportoSaliuIstorijaController : ControllerBase
{
    private void PopulateLists(KovotojoSportoSaliuIstorija i)
    {
        i.NarystesTipaiList = KovotojoSportoSaliuIstorijaRepo.ListNarystesTipai()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();

        i.StatusaiList = KovotojoSportoSaliuIstorijaRepo.ListStatusoTipai()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();

        i.KovotojaiList = KovotojoSportoSaliuIstorijaRepo.ListKovotojai()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = $"{x.Vardas} {x.Pavarde}" })
            .ToList();

        i.SportoSalesList = KovotojoSportoSaliuIstorijaRepo.ListSportoSales()
            .Select(x => new SelectListItem { Value = x.KluboPavadinimas, Text = $"{x.KluboPavadinimas} ({x.Miestas})" })
            .ToList();
    }

    [HttpGet]
    public ActionResult Index()
    {
        return View(KovotojoSportoSaliuIstorijaRepo.List());
    }

    [HttpGet]
    public ActionResult Create()
    {
        var i = new KovotojoSportoSaliuIstorija
        {
            NarystesPradzia = DateTime.Today,
            NarystesPabaiga = DateTime.Today.AddMonths(1)
        };
        PopulateLists(i);
        return View(i);
    }

    [HttpPost]
    public ActionResult Create(KovotojoSportoSaliuIstorija i)
    {
        if (i.NarystesPabaiga < i.NarystesPradzia)
            ModelState.AddModelError("NarystesPabaiga", "Narystės pabaiga negali būti ankstesnė už pradžią.");

        if (ModelState.IsValid)
        {
            KovotojoSportoSaliuIstorijaRepo.Insert(i);
            return RedirectToAction("Index");
        }
        PopulateLists(i);
        return View(i);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var i = KovotojoSportoSaliuIstorijaRepo.Find(id);
        PopulateLists(i);
        return View(i);
    }

    [HttpPost]
    public ActionResult Edit(int id, KovotojoSportoSaliuIstorija i)
    {
        if (i.NarystesPabaiga < i.NarystesPradzia)
            ModelState.AddModelError("NarystesPabaiga", "Narystės pabaiga negali būti ankstesnė už pradžią.");

        if (ModelState.IsValid)
        {
            i.Id = id;
            KovotojoSportoSaliuIstorijaRepo.Update(i);
            return RedirectToAction("Index");
        }
        PopulateLists(i);
        return View(i);
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        return View(KovotojoSportoSaliuIstorijaRepo.Find(id));
    }

    [HttpPost]
    public ActionResult DeleteConfirm(int id)
    {
        try
        {
            KovotojoSportoSaliuIstorijaRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            return View("Delete", KovotojoSportoSaliuIstorijaRepo.Find(id));
        }
    }
}
