using Saguaro.Logging;
using Saguaro.Logging.Models;
using Saguaro.Logging.Types;
using Saguaro.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Saguaro.Controllers
{
    public class HomeController : Controller
    {

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(login.UserName, login.Password, true))
                {
                    if (Roles.IsUserInRole(login.UserName, "Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    UserProfile userProfile = await Sql.SelectStatements.GetUserProfileTask(login.UserName);

                    #region Logging

                    LoggingDataService loggingDataService = new LoggingDataService();
                    string description = userProfile.UserName + " has logged into the system"; ;
                    await loggingDataService.LogAsync(userProfile, LogTypes.Activity, ActivityTypes.Login, description, Request);

                    #endregion

                    return RedirectToAction("Index");

                }
                else
                {
                    return View(login);
                }
            }

            return View(login);
        }

      



        //
        // GET: /Home/
        [Authorize(Roles="User, Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult> LogDownload()
        {
            #region Logging

            UserProfile userProfile = await Sql.SelectStatements.GetUserProfileTask(WebSecurity.CurrentUserName);

            LoggingDataService loggingDataService = new LoggingDataService();
            string description = "xyz.psd"; //<---filename
            await loggingDataService.LogAsync(userProfile, LogTypes.Activity, ActivityTypes.Download, description, Request);

            #endregion

            return Content("Your activity has been logged as a 'download' by the user: '" + userProfile.UserName + "' at: " + TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now.ToUniversalTime(), TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")));
        }
    }
}
