namespace Lab_2_DB.Controllers;

using Lab_2_DB.Models.KovosF2;
using Lab_2_DB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class KovosF2Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(KovosF2Repo.ListKovos());
    }

    [HttpGet]
    public IActionResult Create()
    {
        var ce = new KovaCE
        {
            Kova = { KovosLaikasData = DateTime.Now }
        };
        PopulateLists(ce);
        return View(ce);
    }

    [HttpPost]
    public IActionResult Create(int? save, int? add, int? remove, KovaCE ce)
    {
        if (add != null)
        {
            ce.KovotojuDalyvavimai.Add(new KovaCE.KovotojoDalyvavimasM
            {
                InListId = ce.KovotojuDalyvavimai.Count > 0 ? ce.KovotojuDalyvavimai.Max(x => x.InListId) + 1 : 0,
                BaigtiesRaundas = 1
            });
            ModelState.Clear();
            PopulateLists(ce);
            return View(ce);
        }

        if (remove != null)
        {
            ce.KovotojuDalyvavimai = ce.KovotojuDalyvavimai.Where(x => x.InListId != remove.Value).ToList();
            ModelState.Clear();
            PopulateLists(ce);
            return View(ce);
        }

        if (save != null)
        {
            if (ModelState.IsValid)
            {
                var newId = KovosF2Repo.InsertKova(ce);
                KovosF2Repo.ReplaceKovotojoDalyvavimai(newId, ce.KovotojuDalyvavimai);
                return RedirectToAction(nameof(Index));
            }

            PopulateLists(ce);
            return View(ce);
        }

        throw new Exception("Unexpected action.");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ce = KovosF2Repo.FindKovaCE(id);
        PopulateLists(ce);
        return View(ce);
    }

    [HttpPost]
    public IActionResult Edit(int id, int? save, int? add, int? remove, KovaCE ce)
    {
        ce.Kova.Id = id;

        if (add != null)
        {
            ce.KovotojuDalyvavimai.Add(new KovaCE.KovotojoDalyvavimasM
            {
                InListId = ce.KovotojuDalyvavimai.Count > 0 ? ce.KovotojuDalyvavimai.Max(x => x.InListId) + 1 : 0,
                BaigtiesRaundas = 1
            });
            ModelState.Clear();
            PopulateLists(ce);
            return View(ce);
        }

        if (remove != null)
        {
            ce.KovotojuDalyvavimai = ce.KovotojuDalyvavimai.Where(x => x.InListId != remove.Value).ToList();
            ModelState.Clear();
            PopulateLists(ce);
            return View(ce);
        }

        if (save != null)
        {
            if (ModelState.IsValid)
            {
                KovosF2Repo.UpdateKova(ce);
                KovosF2Repo.ReplaceKovotojoDalyvavimai(id, ce.KovotojuDalyvavimai);
                return RedirectToAction(nameof(Index));
            }

            PopulateLists(ce);
            return View(ce);
        }

        throw new Exception("Unexpected action.");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        return View(KovosF2Repo.FindKovaCE(id));
    }

    [HttpPost]
    public IActionResult DeleteConfirm(int id)
    {
        KovosF2Repo.DeleteKova(id);
        return RedirectToAction(nameof(Index));
    }

    private static void PopulateLists(KovaCE ce)
    {
        ce.Lists.KovosStatusai = LookUpLentelesRepo.ListKovosStatusas()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();

        ce.Lists.SvorioKategorijos = SvorioKategorijaRepo.List()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.KategorijosPavadinimas })
            .ToList();

        ce.Lists.Renginiai = RenginysRepo.List()
            .Select(x => new SelectListItem { Value = x.RenginioPavadinimas, Text = x.RenginioPavadinimas })
            .ToList();

        ce.Lists.KovosTaisykles = KovosTaisyklesRepo.List()
            .Select(x => new SelectListItem { Value = x.TaisykliuPavadinimas, Text = x.TaisykliuPavadinimas })
            .ToList();

        ce.Lists.Kovotojai = KovotojasRepo.List()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = $"{x.Vardas} {x.Pavarde}" })
            .ToList();

        ce.Lists.BaigtiesBudai = LookUpLentelesRepo.ListKovosPabaigosTipai()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();

        ce.Lists.Rezultatai = LookUpLentelesRepo.ListLaimejimoRezultatas()
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();
    }
}
