using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class DepartamentoController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Departamento/

        public ActionResult Index()
        {
            return View(_db.DepartamentoSet.ToList());
        }

        //
        // GET: /Departamento/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Departamento/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Departamento/Create

        [HttpPost]
        public ActionResult Create(Departamento departamentoToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)

                    return View(departamentoToCreate);

                _db.AddToDepartamentoSet(departamentoToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Departamento/Edit/5
 
        public ActionResult Edit(int id)
        {
            var departamentoToEdit = (from m in _db.DepartamentoSet

                                      where m.ID_DEPTO == id

                                      select m).First();

            return View(departamentoToEdit);
        }

        //
        // POST: /Departamento/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Departamento departamentoToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalDept = (from m in _db.DepartamentoSet

                                     where m.ID_DEPTO == departamentoToEdit.ID_DEPTO

                                     select m).First();

                if (!ModelState.IsValid)

                    return View(originalDept);

                _db.ApplyCurrentValues(originalDept.EntityKey.EntitySetName, departamentoToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Departamento/Delete/5
 
        public ActionResult Delete(int id)
        {
            var departamentoToDelete = (from m in _db.DepartamentoSet

                                        where m.ID_DEPTO == id

                                        select m).First();

            return View(departamentoToDelete);
        }

        //
        // POST: /Departamento/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Departamento departamentoToDelete)
        {
            try
            {
                // TODO: Add delete logic here
                var departamentoDelete = (from m in _db.DepartamentoSet

                                          where m.ID_DEPTO == id

                                          select m).First();

                _db.DeleteObject(departamentoDelete);

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
