using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Infrastrucutre;
using Cinema.Infrastrucutre.Repositories;

namespace Cinema.Admin.Controllers
{
    public class TheaterController : Controller
    {
        private ITheaterRepository _theaterRepository;

        public TheaterController()
        {
            string cnn = ConfigurationManager.ConnectionStrings["CinemaCnn"].ToString();
            var dbContext = new DatabaseContext(cnn);
            var theaterRepo = new TheaterRepository(dbContext);
            _theaterRepository = theaterRepo;
        }

        // GET: Theater
        public ActionResult Index()
        {
            var result = _theaterRepository.GetAll();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Theater model)
        {
            if (ModelState.IsValid)
            {
                _theaterRepository.Add(model);
                _theaterRepository.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}