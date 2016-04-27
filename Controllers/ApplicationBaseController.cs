using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayerr;


namespace VFeeD.Controllers
{
    public class ApplicationBaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    String user = User.Identity.Name;
                    UserDataLayer uctx = new UserDataLayer();
                    UserDetails usrdtls = uctx.getUser(user);
                    //string fullName = string.Concat(new string[] { usrdtls.Fname, " ", usrdtls.Lname });
                    string fullName = "";
                    fullName = usrdtls.Fname + " " + usrdtls.Lname;
                    ViewData.Add("FullName", fullName);
                }
            }
            base.OnActionExecuted(filterContext);
        }
        public ApplicationBaseController()
        { }
    }
}