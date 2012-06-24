using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class MunicipioController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Municipio/

        public ActionResult Index()
        {
            return View(_db.MunicipioSet.ToList());
        }

        //
        // GET: /Municipio/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Municipio/Create

        public ActionResult Create()
        {
            var query = _db.DepartamentoSet.Select(c => new { c.ID_DEPTO, c.NOMBRE_DEPTO });

            ViewBag.ID_DEPTO = new SelectList(query.AsEnumerable(), "ID_DEPTO", "NOMBRE_DEPTO");

            return View();
        }

        //
        // POST: /Municipio/Create

        [HttpPost]
        public ActionResult Create(Municipio municipioToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    var query = _db.DepartamentoSet.Select(c => new { c.ID_DEPTO, c.NOMBRE_DEPTO });

                    ViewBag.ID_DEPTO = new SelectList(query.AsEnumerable(), "ID_DEPTO", "NOMBRE_DEPTO");

                    return View(municipioToCreate);
                }

                _db.AddToMunicipioSet(municipioToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Municipio/Edit/5
 
        public ActionResult Edit(int id)
        {
            var municipioToEdit = (from m in _db.MunicipioSet

                                      where m.ID_MUNICIPIO == id

                                      select m).First();

            return View(municipioToEdit);
        }

        //
        // POST: /Municipio/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Municipio municipioToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalMuni = (from m in _db.MunicipioSet

                                    where m.ID_MUNICIPIO == municipioToEdit.ID_MUNICIPIO

                                    select m).First();

                if (!ModelState.IsValid)

                    return View(originalMuni);

                _db.ApplyCurrentValues(originalMuni.EntityKey.EntitySetName, municipioToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Municipio/Delete/5
 
        public ActionResult Delete(int id)
        {
            var municipioToDelete = (from m in _db.MunicipioSet

                                        where m.ID_MUNICIPIO == id

                                        select m).First();

            return View(municipioToDelete);
        }

        //
        // POST: /Municipio/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Municipio municipioToDelete)
        {
            try
            {
                // TODO: Add delete logic here
                var municipioDelete = (from m in _db.MunicipioSet

                                          where m.ID_MUNICIPIO == id

                                          select m).First();

                _db.DeleteObject(municipioDelete);

                _db.SaveChanges();

 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
