namespace Lab_2_DB.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab_2_DB.Models;
using Lab_2_DB.Repositories;

public class KovosRaundoInfoController : ControllerBase
{
    private void PopulateLists(KovosRaundoInfo r)
    {
        r.RaundoPabaigosTipaiList = KovosRaundoInfoRepo.ListRaundoPabaigosTipai()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();

        r.KovosDuomenysList = KovosRaundoInfoRepo.ListKovos()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = $"#{x.Id} ({x.KovosLaikasData:yyyy-MM-dd HH:mm})" })
            .ToList();
    }

    [HttpGet]
    public ActionResult Index()
    {
        return View(KovosRaundoInfoRepo.List());
    }

    [HttpGet]
    public ActionResult Create()
    {
        var r = new KovosRaundoInfo();
        PopulateLists(r);
        return View(r);
    }

    [HttpPost]
    public ActionResult Create(KovosRaundoInfo r)
    {
        if (ModelState.IsValid)
        {
            KovosRaundoInfoRepo.Insert(r);
            return RedirectToAction("Index");
        }
        PopulateLists(r);
        return View(r);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var r = KovosRaundoInfoRepo.Find(id);
        PopulateLists(r);
        return View(r);
    }

    [HttpPost]
    public ActionResult Edit(int id, KovosRaundoInfo r)
    {
        if (ModelState.IsValid)
        {
            r.Id = id;
            KovosRaundoInfoRepo.Update(r);
            return RedirectToAction("Index");
        }
        PopulateLists(r);
        return View(r);
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        return View(KovosRaundoInfoRepo.Find(id));
    }

    [HttpPost]
    public ActionResult DeleteConfirm(int id)
    {
        try
        {
            KovosRaundoInfoRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            return View("Delete", KovosRaundoInfoRepo.Find(id));
        }
    }
}
