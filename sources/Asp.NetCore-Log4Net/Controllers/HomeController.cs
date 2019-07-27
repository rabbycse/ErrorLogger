using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asp.NetCore_Log4Net.Models;
using Microsoft.Extensions.Logging;

namespace Asp.NetCore_Log4Net.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("RollingFile");

            logger.LogCritical("Hello");

#if DEBUG
            logger.LogDebug("This is a debug log");
#endif
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
