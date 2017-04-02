using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webinject_check.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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
            //List<Search> searches = GetSearches(model);
            string result = GetSearches(model);
            //SearchBusinessLayer bal = new SearchBusinessLayer();
            //bal.UploadSearches(searches);
            //ViewBag.Message = string.Join(",", searches);

            //string message = "";
            //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(searches))
            //{
            //    string name = descriptor.Name;
            //    object value = descriptor.GetValue(searches);
            //    Console.WriteLine("{0}={1}", name, value);
            //    message += String.Format("{0}={1}", name, value);
            //}

            //ViewBag.Message = message;
            ViewBag.Message = result;
            return View();
            //return RedirectToAction("Confirmation", "BulkUpload");
        }

        private string GetSearches(FileUploadViewModel model)
        {

            string summary = "";
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
                s.MaxPrepTime = values[2];
                searches.Add(s);
                summary = summary + " Dish[" + values[0] + "] Cuisine[" + values[1] + "] PrepTime[" + values[2] + "] ::::";
            }
            //return searches;
            return summary;
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
