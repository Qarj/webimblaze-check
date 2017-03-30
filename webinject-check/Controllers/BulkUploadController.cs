using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webinject_check.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace webinject_check.Controllers
{
    public class BulkUploadController : Controller
    {

        // GET: BulkUpload
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        public ActionResult Upload(FileUploadViewModel model)
        {
            List<Search> searches = GetSearches(model);
            //SearchBusinessLayer bal = new SearchBusinessLayer();
            //bal.UploadSearches(searches);
            return RedirectToAction("Confirmation", "BulkUpload");
        }

        private List<Search> GetSearches(FileUploadViewModel model)
        {
            List<Search> searches = new List<Search>();
            StreamReader csvreader = new StreamReader(model.fileUpload.OpenReadStream());

            csvreader.ReadLine(); // Assuming first line is header
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var values = line.Split(',');//Values are comma separated
                Search s = new Search();
                s.RecipeName = values[0];
                s.Cuisine = values[1];
                s.MaxPrepTime = int.Parse(values[2]);
                searches.Add(s);
            }
            return searches;
        }

        public ActionResult Confirmation()
        {
            ViewBag.Message = "You have uploaded a correctly formatted file.";

            return View();
        }

        [HttpPost]
        public ActionResult XML(FileUploadViewModel model)
        {

            return RedirectToAction("Confirmation", "BulkUpload");


        }
    }
}
