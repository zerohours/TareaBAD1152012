﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TareaBAD1152012.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Sistema de Expediente Clínico de Hospitales";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
