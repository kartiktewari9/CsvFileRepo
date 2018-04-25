using CsvFileProject.Common.Objects.ViewModels;
using CsvFileProject.Common.Services.Services;
using CsvFileWebsite.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsvFileWebsite.Controllers
{
    public class HomeController : Controller
    {

        private ICustomerService _customerService;
        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        var model = new HomeIndexViewModel();
                        model.Customers = _customerService.GetCustomers(stream);
                        return View(model);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }

        public ActionResult CreateCustomerCsv()
        {
            ViewBag.Result = "";
            var model = new HomeIndexViewModel();
            model.Customers.Add(new CustomerViewModel
            {
                Id=string.Empty,
                Name= string.Empty,
                Address= string.Empty,
                Email= string.Empty,
                Mobile= string.Empty
            });
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCustomerCsv(HomeIndexViewModel model)
        {
            ViewBag.Result = "";
            if (ModelState.IsValid)
            {
                if(model.Customers.Count<1)
                    ModelState.AddModelError("Customers", "Atleast one customer is mandatory to add to create a csv file!");
                else
                {
                    var fileName = Guid.NewGuid().ToString();
                    var stream = new StreamWriter(@"F:\Projects\CsvFileRepo\CSVFileProject\CsvFileWebsite\App_Data\CreatedCsv\"+ fileName+".csv");
                    _customerService.WriteCustomers(stream, model.Customers);
                    ViewBag.Result = "Success";
                    ModelState.AddModelError("", @"File created successfully at location F:\Projects\CsvFileRepo\CSVFileProject\CsvFileWebsite\App_Data\CreatedCsv\"+ fileName + ".csv");
                }
            }
            else
            {
                ModelState.AddModelError("","There is some issue in validating the model!");
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}