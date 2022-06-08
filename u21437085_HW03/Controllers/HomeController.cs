using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace u21437085_HW03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
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

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string radiobutton)
        {
            if (radiobutton == "Document")
            {
                var Fname = FilePathResult.GetFileName(files.FileName);
                var Path = Path.Combine(Server.MapPath("~/App_Data/Documents/"), Fname);
                files.SaveAs(path);
            }

            if (radiobutton == "Image")
            {
                var Fname = FilePathResult.GetFileName(files.FileName);
                var Path = Path.Combine(Server.MapPath("~/App_Data/Images/"), Fname);
                files.SaveAs(path);
            }

            if (radiobutton == "Video")
            {
                var Fname = FilePathResult.GetFileName(files.FileName);
                var Path = Path.Combine(Server.MapPath("~/App_Data/Videos/"), Fname);
                files.SaveAs(path);
            }

        }

    }
}