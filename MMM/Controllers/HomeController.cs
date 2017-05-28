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
        //public ActionResult Index()
        //{
        //    return View();
        //}\

        private readonly IWriteTestMessage _writeTestMessage;

        public HomeController(IWriteTestMessage writeTestMessage)
        {
            this._writeTestMessage = writeTestMessage;
        }

        public string Index()
        {
            return this._writeTestMessage.GetTestMessage();
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