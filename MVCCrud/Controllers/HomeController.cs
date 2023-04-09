﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDBContext _context = new MVCCRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Students.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Inserted";
            return View();
        }
        public ActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.StudentID == id).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Student Model)
        {
            var data = _context.Students.Where(x => x.StudentID == Model.StudentID).FirstOrDefault();
            if (data != null)
            {

                data.StudentCity = Model.StudentCity;
                data.StudentName = Model.StudentName;
                data.StudentFees = Model.StudentFees;
                _context.SaveChanges();
            }
            return RedirectToAction("index");


        }
        public ActionResult Detail(int id)
        {
            var data = _context.Students.Where(x => x.StudentID == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Students.Where(x => x.StudentID == id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Deleted";
            return RedirectToAction("index");
        }




        /*        public ActionResult About()
                {
                    ViewBag.Message = "Your application description page.";

                    return View();
                }

                public ActionResult Contact()
                {
                    ViewBag.Message = "Your contact page.";

                    return View();
                }*/
    }
}