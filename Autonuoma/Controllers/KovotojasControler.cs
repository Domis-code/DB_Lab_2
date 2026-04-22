using Microsoft.AspNetCore.Mvc;

namespace Lab_2_DB.Controllers
{
    using Lab_2_DB.Repositories;
    using Lab_2_DB.Models;
    public class KovotojasController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(KovotojasRepo.List());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Kovotojas { GimimoData = new DateTime(1995, 1, 1) });

        }
        [HttpPost]
        public ActionResult Create(Kovotojas kovotojas)
        {
            if (ModelState.IsValid)
            {
                KovotojasRepo.Insert(kovotojas);
                return RedirectToAction("Index");
            }
            return View(kovotojas);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(KovotojasRepo.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Kovotojas kovotojas)
        {
            if (ModelState.IsValid)
            {
                kovotojas.Id = id;
                KovotojasRepo.Update(kovotojas);
                return RedirectToAction("Index");
            }
            return View(kovotojas);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(KovotojasRepo.Find(id));
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                KovotojasRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch(MySql.Data.MySqlClient.MySqlException)
            {
                ViewData["deletionNotPermitted"] = true;
                return View("Delete", KovotojasRepo.Find(id));
            }
        }
    }
}
