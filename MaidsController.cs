using Miad_api.Models;
using Miad_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace Miad_api.Controllers
{
    public class MaidsController : Controller
    {
        // GET: MaidsController
        //public ActionResult Index()
        //{
        //    List<MaidsController> list = new List<MaidsController>();
        //    return View(list);
        //}
        public IActionResult Index()
        {
            // Correctly fetch the list of Maids from your service or repository
            var maids = Maids.GetAllMaids();
            return View(maids);
            //List<MaidsController> list = new List<MaidsController>();
            //    return View(list);
        }

        // GET: MaidsController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
                return NotFound();
            Maids obj = Maids.GetMaidbyId(id.Value);
            if (obj == null)
                ViewBag.error = "No Maid Found";
            return View(obj);
        }

        // GET: MaidsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaidsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Maids obj)
        {
            try
            {
                Maids.Insert(obj);
                ViewBag.message = "Success";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaidsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            return NotFound();

            Maids obj = Maids.GetMaidbyId(id.Value);
            if (obj == null)
                ViewBag.error = "No Maid Found";
            return View(obj);
        }

        // POST: MaidsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Maids obj)
        {
            try
            {
                Maids.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaidsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

             Maids obj = Maids.GetMaidbyId(id.Value);
            if (obj == null)
                ViewBag.error = "No Maid Found";
            return View(obj);
        }

        // POST: MaidsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, Maids obj)
        {
            try
            {
                Maids.Delete(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
