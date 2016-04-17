using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayerr;

namespace VFeeD.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Store()
        {
            EdibleDataLayer ectx = new EdibleDataLayer();
            //List<string> NearByZipCodes = new List<string>();
            List<Edible> StoresAround1 = new List<Edible>();
            if (!string.IsNullOrEmpty("19333"))
            {
                List<Edible> StoresAround = ectx.GetEdiblePages();
                Console.WriteLine(StoresAround.Count);
                StoresAround1 = StoresAround;
                Console.WriteLine("Im here");
            }

            return View(StoresAround1);
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
