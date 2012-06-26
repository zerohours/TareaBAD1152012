using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaBAD1152012.Models;

namespace TareaBAD1152012.Controllers
{
    public class PersonaController : Controller
    {

        private BadDBEntities _db = new BadDBEntities();

        //
        // GET: /Persona/

        public ActionResult Index()
        {
            return View(_db.PersonaSet.ToList());
        }

        //
        // GET: /Persona/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Persona/Create

        [Authorize(Users="administrador")]
        public ActionResult Create()
        {

            var query = _db.DepartamentoSet.Select(c => new { c.ID_DEPTO, c.NOMBRE_DEPTO });

            ViewData["ID_DEPTO"] = new SelectList(query.AsEnumerable(), "ID_DEPTO", "NOMBRE_DEPTO");

            var query2 = _db.MunicipioSet.Select(c => new { c.ID_MUNICIPIO, c.NOMBRE_MUNICIPIO });

            ViewBag.ID_MUNICIPIO = new SelectList(query2.AsEnumerable(), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");

            return View();
        } 

        //
        // POST: /Persona/Create

        [HttpPost]
        public ActionResult Create(Persona personaToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {

                    var query = _db.DepartamentoSet.Select(c => new { c.ID_DEPTO, c.NOMBRE_DEPTO });

                    ViewBag.ID_DEPTO = new SelectList(query.AsEnumerable(), "ID_DEPTO", "NOMBRE_DEPTO");

                    var query2 = _db.MunicipioSet.Select(c => new { c.ID_MUNICIPIO, c.NOMBRE_MUNICIPIO });

                    ViewBag.ID_MUNICIPIO = new SelectList(query2.AsEnumerable(), "ID_MUNICIPIO", "NOMBRE_MUNICIPIO");

                    return View(personaToCreate);
                }


                _db.AddToPersonaSet(personaToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Persona/Edit/5

        [Authorize]
        public ActionResult Edit(int id)
        {
            var personaToEdit = (from m in _db.PersonaSet

                                   where m.ID_PERSONA == id

                                   select m).First();

            return View(personaToEdit);
        }

        //
        // POST: /Persona/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Persona personaToEdit)
        {
            try
            {
                // TODO: Add update logic here
                var originalPerson = (from m in _db.PersonaSet

                                      where m.ID_PERSONA == personaToEdit.ID_PERSONA

                                    select m).First();

                if (!ModelState.IsValid)

                    return View(originalPerson);

                _db.ApplyCurrentValues(originalPerson.EntityKey.EntitySetName, personaToEdit);

                _db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Persona/Delete/5
 
        public ActionResult Delete(int id)
        {
            var personaToDelete = (from m in _db.PersonaSet

                                     where m.ID_PERSONA == id

                                     select m).First();

            return View(personaToDelete);
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Persona personaToDelete)
        {
            try
            {
                // TODO: Add delete logic here
                var personaDelete = (from m in _db.PersonaSet

                                       where m.ID_PERSONA == id

                                       select m).First();

                _db.DeleteObject(personaDelete);

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
