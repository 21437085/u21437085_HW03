﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21437085_HW03.Models;



namespace u21437085_HW03.Controllers
{

    public class FileController : Controller
    {
        [HttpGet]
        public ActionResult Index() 
        {
            return View();

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Documents/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);

        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {

            if (files != null && files.ContentLength > 0)
            {

                var fileName = Path.GetFileName(files.FileName);


                var path = Path.Combine(Server.MapPath("~/App_Data/Documents"), fileName);


                files.SaveAs(path);
            }


            return RedirectToAction("Index");
        }


        

        public FileResult DownloadFile(string fileName) 
        {

            string path = Server.MapPath("~/App_Data/Documents/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {

            string path = Server.MapPath("~/App_Data/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }

    }
}