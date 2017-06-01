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

        private readonly IWriteTestMessage _writeTestMessage;

        public HomeController(IWriteTestMessage writeTestMessage)
        {
            this._writeTestMessage = writeTestMessage;
        }

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