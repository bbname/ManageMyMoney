using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMM.Service.Interfaces;

namespace MMM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public FileResult CvDownload()
        {
            string filename = "~/Content/CV.pdf";
            var file = File(filename, "application/pdf", "CV.pdf");

            return file;
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}