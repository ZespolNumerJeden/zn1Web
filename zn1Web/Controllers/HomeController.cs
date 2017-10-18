using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zn1Web.Models;
using zn1Web.Utils;

namespace zn1Web.Controllers
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

	    public ActionResult Agenda()
	    {
		    var ag = new AgendaGenerator();
		    var agenda = ag.GetAgenda();
			ag.Close();
		    return View(new AgendaViewModel() {Agenda = agenda});
	    }
    }
}