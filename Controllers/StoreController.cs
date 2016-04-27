using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayerr;
using Microsoft.AspNet.Identity;

namespace VFeeD.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        [Authorize]
        public ActionResult Store()
        {
            String user = User.Identity.GetUserName();
            UserDataLayer uctx = new UserDataLayer();
            UserDetails usrdtls = uctx.getUser(user);
            EdibleDataLayer ectx = new EdibleDataLayer();
            //List<string> NearByZipCodes = new List<string>();
            List<Edible> StoresAround1 = new List<Edible>();
            if (!string.IsNullOrEmpty(usrdtls.Zipcode.ToString()))
            {
                List<Edible> StoresAround = ectx.GetEdiblePages(usrdtls.Zipcode.ToString());
                StoresAround1 = StoresAround;
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
                EdibleDataLayer edbldtcx = new EdibleDataLayer();
                Edible store = new Edible
                {
                    Name = Convert.ToString(collection["Name"]),
                    Email = Convert.ToString(collection["Email"]),
                    Zipcode = Convert.ToString(collection["Zipcode"]),
                    ClosingTime = DateTime.Now 
                };
                Random rnd = new Random();
                int minute = rnd.Next(1, 60);
                DateTime dt = new DateTime(store.ClosingTime.Year, store.ClosingTime.Month, store.ClosingTime.Day, rnd.Next(18,23), minute, 0);
                store.ClosingTime = dt;
                //store.ClosingTime.AddHours(8);
                //store.ClosingTime.AddMinutes(minute);
                Console.WriteLine(store.ClosingTime);
                // TODO: Add insert logic here
                edbldtcx.AddStore(store);
                return RedirectToAction("Store");
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
