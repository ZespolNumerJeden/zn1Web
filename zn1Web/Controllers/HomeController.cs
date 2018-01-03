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

        public ActionResult Agenda(bool mobile = false)
        {
            var ag = new AgendaGenerator();
            var agenda = ag.GetAgenda();
            ag.Close();
            var model = new AgendaViewModel() {Agenda = agenda, IsMobile = mobile};

            if (mobile)
            {
                return PartialView("Agenda", model);
            }
            return View(model);
        }


		public ActionResult Report()
		{
			return View();
		}
		public ActionResult ConferenceRegister()
		{
			return View();
		}
		[HttpPost]
		public  ActionResult ConferenceRegister(ConferenceRegisterModel model)
		{
			if (ModelState.IsValid)
			{

				// zapisz rejestracje....
				return null;
				
			}
			return View(model);
		}
	}
}