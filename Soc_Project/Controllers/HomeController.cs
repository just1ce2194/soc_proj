using Soc_Project.BLL.Models;
using Soc_Project.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soc_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ISocialService SocialService;

        public HomeController(ISocialService socialService)
        {
            this.SocialService = socialService;
        }

        public ActionResult Index()
        {
            var model = SocialService.GetJobs();

            return View(model);
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

        public ActionResult People()
        {
            ViewBag.Message = "People";

            var model = SocialService.GetPeople();

            return View(model);
        }

        public ActionResult Person(long? id)
        {
            ViewBag.Message = "Person";

            var model = SocialService.GetPerson(id);

            return View(model);
        }

        public ActionResult Organization(long id)
        {
            ViewBag.Message = "Organization";

            var model = SocialService.GetPerson(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult AddPerson(PersonVm model)
        {
            ViewBag.Message = "Person";

            SocialService.AddPerson(model);

            return RedirectToAction("People");
        }
    }
}