using Saguaro.Logging;
using Saguaro.Logging.Models;
using Saguaro.Logging.Types;
using Saguaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Saguaro.Controllers
{
    public class AdminController : Controller
    {
        
        // GET: /Admin/
        [Authorize(Roles="Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        // GET: /Admin/Environment
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Environment()
        {
            return Content(EnvironmentSettings.Environment.Current);
        }


        // GET: /Admin/LogError
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> LogError()
        {
            UserProfile userProfile = await Sql.SelectStatements.GetUserProfileTask(WebSecurity.CurrentUserName);

            LoggingDataService loggingDataService = new LoggingDataService();
            string description = "Test error logged by the 'LogError' Controller";
            await loggingDataService.LogAsync(userProfile, LogTypes.Error, ErrorTypes.Exception, description, Request);

            return Content("Test error logged");
        }


    }
}
