using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Saguaro.Controllers
{
    public class SignoutController : Controller
    {
        //
        //GET: /SignOut
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Index()
        {
            if (WebSecurity.IsAuthenticated)
            {
                WebSecurity.Logout();
                return Content("You have been signed out.");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
