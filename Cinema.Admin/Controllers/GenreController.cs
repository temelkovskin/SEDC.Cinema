using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Domain.Entities;
using Cinema.Infrastrucutre;
using Cinema.SharedModels;
using Cinema.Domain.Interfaces;
using Cinema.Infrastrucutre.Repositories;

namespace Cinema.Admin.Controllers
{
    public class GenreController : Controller
    {
        private IGenreRepository _genreRepository;

        public GenreController()
        {
            string cnn = ConfigurationManager.ConnectionStrings["CinemaCnn"].ToString();
            var dbContext = new DatabaseContext(cnn);
            var genreRepo = new GenreRepository(dbContext);
            _genreRepository = genreRepo;
        }


        public ActionResult Index()
        {
            var result = _genreRepository.GetAll();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre model)
        {
            if (ModelState.IsValid)
            {
                _genreRepository.Add(model);
                _genreRepository.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _genreRepository.Delete(id);
            _genreRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
