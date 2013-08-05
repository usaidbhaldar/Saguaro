using Saguaro.Logging.TableEntities;
using Saguaro.Logging.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Saguaro.Controllers
{
    public class ReportsController : Controller
    {
        
        // GET: /Reports/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }


        // GET: /Reports/All/
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> All()
        {
            Logging.LoggingDataService logging = new Logging.LoggingDataService();
            var allLogs = await logging.GetLogsByTimeAsync(LogTypes.Activity, 1200);

            return View(allLogs);
        }

        // GET: /Reports/Platform/
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Platform()
        {
            Logging.LoggingDataService logging = new Logging.LoggingDataService();
            var allLogs = await logging.GetLogsByTimeAsync(LogTypes.Platform, 1200);

            return View(allLogs);
        }


        // GET: /Reports/Activity/{type}
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Activity(string id)
        {
            Logging.LoggingDataService logging = new Logging.LoggingDataService();
            var activityLogs = await logging.GetLogsByActivityAsync(LogTypes.Activity, id, 1200);

            return View(activityLogs);
        }


        // GET: /Reports/Activity/{type}
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> IP(string id)
        {
            Logging.LoggingDataService logging = new Logging.LoggingDataService();
            var activityLogs = await logging.GetLogsByIPAddressAsync(LogTypes.Activity, id, 1200);

            return View(activityLogs);
        }

        // GET: /Reports/Users/{username}
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Users(string id)
        {
            Logging.LoggingDataService logging = new Logging.LoggingDataService();
            var userLogs = await logging.GetLogsByUserAsync(LogTypes.Activity, id, 800);

            return View(userLogs);
        }

    }
}
