namespace Lab_2_DB.Controllers;

using Microsoft.AspNetCore.Mvc;
using Lab_2_DB.Models;
using Lab_2_DB.Repositories;
using System.Linq;


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
        return View(BuildEditVm(id));
    }

    [HttpPost]
    public ActionResult Edit(string id, KovinioSportoSaleF2 vm, string actionType)
    {
        if (actionType == "assign")
        {
            var trenerisId = vm.PasirinktasTrenerisId;
            if (!trenerisId.HasValue)
                ModelState.AddModelError("PasirinktasTrenerisId", "Pasirinkite trenerį priskyrimui.");

            if (ModelState.IsValid)
            {
                TrenerisRepo.AssignToSale(trenerisId!.Value, id);
                return RedirectToAction("Edit", new { id });
            }

            vm = BuildEditVm(id, vm.Sale);
            return View(vm);
        }

        if (ModelState.IsValid)
        {
            try
            {
                KovinioSportoSaleRepo.Update(id, vm.Sale);
                return RedirectToAction("Index");
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                ModelState.AddModelError("Sale.KluboPavadinimas", "Klubas tokiu pavadinimu jau egzistuoja arba naudojamas.");
            }
        }

        vm = BuildEditVm(id, vm.Sale);
        return View(vm);
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

    private static KovinioSportoSaleF2 BuildEditVm(string id, KovinioSportoSale? saleFromPost = null)
    {
        var sale = saleFromPost ?? KovinioSportoSaleRepo.Find(id);
        sale.OriginalPK = id;

        var visiTreneriai = TrenerisRepo.List();
        var vm = new KovinioSportoSaleF2
        {
            Sale = sale,
            PriskirtiTreneriai = TrenerisRepo.ListBySale(id),
            TreneriaiPasirinkimui = visiTreneriai
                .Select(t => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = $"{t.Vardas} {t.Pavarde} ({t.Specializacija})"
                })
                .ToList()
        };

        return vm;
    }
}



