using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Domain;
using Cinema.Infrastrucutre;
using Cinema.Infrastrucutre.Repositories;
using Cinema.Services.Services;
using Cinema.SharedModels;

namespace Cinema.Admin.Controllers
{
    public class MoviesController : Controller
    {
        private MovieService _movieService;
        private MovieRepository _movieRepository;
        private TheaterRepository _theaterRepository;
        private GenreRepository _genreRepository;
        private TimeIntervalRepository _timeIntervalRepository;
        private GenreService _genreService;
        private TheaterService _theaterService;

        public MoviesController()
        {
            string cnn = ConfigurationManager.ConnectionStrings["CinemaCnn"].ToString();
            var dbContext = new DatabaseContext(cnn);

            var movieRepository = new MovieRepository(dbContext);
            var theaterRepository = new TheaterRepository(dbContext);
            var genreRepository = new GenreRepository(dbContext);
            var timeIntervalRepository = new TimeIntervalRepository(dbContext);
            
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _theaterRepository = theaterRepository;
            _timeIntervalRepository = timeIntervalRepository;

            _movieService = new MovieService(movieRepository, theaterRepository, 
                _genreRepository, timeIntervalRepository);
            _genreService = new GenreService(_genreRepository);
            _theaterService = new TheaterService(theaterRepository);
        }


        public ActionResult AddMovie()
        {
            Movie_GenreTheaterDTO model = new Movie_GenreTheaterDTO()
            {
                Movie = new Movie(),

                Genres = _genreService.GetAllGenres().Select(x => new SelectListItem()
                {
                    Text = x.Description,
                    Value = x.Id.ToString()
                }).ToList(),

                Theater = _theaterService.GetAllTheaters().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList(),

                TimesList = _timeIntervalRepository.GetAll(), 
                TimeIntervals = _timeIntervalRepository.GetAll()
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult AddMovie(Movie_GenreTheaterDTO model)
        {
            if (ModelState.IsValid)
            {
                _movieService.AddMovie(model);
                return RedirectToAction("Index", "Home", new {area = ""});
            }
            return View(model);
        }

    }

    


}