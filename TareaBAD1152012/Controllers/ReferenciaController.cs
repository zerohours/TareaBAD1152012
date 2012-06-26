using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class ReferenciaController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Referencia/

        public ActionResult Index()
        {
            return View(_db.ReferenciaSet.ToList());
        }

        //
        // GET: /Referencia/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Referencia/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Referencia/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Referencia/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Referencia/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Referencia/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Referencia/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
