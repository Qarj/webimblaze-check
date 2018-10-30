using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webimblaze_check.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "webinject-check provides a web site for automated test examples.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Qarj on GitHub.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public ActionResult Pictures()
        {
            ViewData["Message"] = "The Pictures Page.";

            return View();
        }

        public ActionResult JavaScript()
        {
            ViewData["Message"] = "The JavaScript Page.";

            return View();
        }

        public ActionResult Special()
        {
            ViewData["Message"] = "Here be links to special things.";

            return View();
        }


    }
}
