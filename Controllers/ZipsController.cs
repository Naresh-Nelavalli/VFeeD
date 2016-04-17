using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayerr;

namespace VFeeD.Controllers
{
    public class ZipsController : Controller
    {
        // GET: Zips
        public ActionResult Index()
        {
            LocationDataLayer lctx = new LocationDataLayer();
            List<string> NearByZipCodes = new List<string>();
            List<Location> locationsAround1 = new List<Location>();
            if (!string.IsNullOrEmpty("19333"))
            {
                List<Location> locationsAround = lctx.GetNearZipcodes("19333", 100);
                Console.WriteLine(locationsAround.Count);
                locationsAround1 = locationsAround;
                Console.WriteLine("Im here");
             }

            return View(locationsAround1);
        }

        // GET: Zips/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       
    }
}
