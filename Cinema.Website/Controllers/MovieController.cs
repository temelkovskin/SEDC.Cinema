using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Infrastrucutre;
using Cinema.Infrastrucutre.Repositories;
using Cinema.Services.Services;
using Cinema.SharedModels.DTOs;

namespace Cinema.Website.Controllers
{
    public class MovieController : Controller
    {
        private MovieService _movieService;
        private MovieRepository _movieRepository;
        private TheaterRepository _theaterRepository;
        private GenreRepository _genreRepository;
        private UserRepository _userRepository;
        private TimeIntervalRepository _timeIntervalRepository;
        private GenreService _genreService;
        private TheaterService _theaterService;

        private static string _username;

         public MovieController()
        {
            string cnn = ConfigurationManager.ConnectionStrings["CinemaCnn"].ToString();
            var dbContext = new DatabaseContext(cnn);

            var movieRepository = new MovieRepository(dbContext);
            var theaterRepository = new TheaterRepository(dbContext);
            var genreRepository = new GenreRepository(dbContext);
            var timeIntervalRepository = new TimeIntervalRepository(dbContext);
            var userRepository = new UserRepository(dbContext);
            

            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _theaterRepository = theaterRepository;
            _timeIntervalRepository = timeIntervalRepository;
             _userRepository = userRepository;

            _movieService = new MovieService(movieRepository, theaterRepository, 
                _genreRepository, timeIntervalRepository);
            _genreService = new GenreService(_genreRepository);
            _theaterService = new TheaterService(theaterRepository);
        }


        // GET: Movie
         public ActionResult Index(string username)
         {
            _username = username;
            var model = _movieService.GetAllMovies();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string searchTitle, string searchDescription, string searchDate)
        {
            var model = _movieService.GetAllMovies();

            if (!String.IsNullOrEmpty(searchTitle))
            {
                model = model.Where(x => x.Title.ToUpper().Contains(searchTitle.ToUpper())).ToList();
            }

            if (!String.IsNullOrEmpty(searchDescription))
            {
                model = model.Where(x => x.Description.ToUpper().Contains(searchDescription.ToUpper())).ToList();
            }

            if (!String.IsNullOrEmpty(searchDate))
            {
                model = model.Where(x => x.StartingDate.ToString("DD/MM/YYYY").Contains(searchDate)).ToList();
            }
            

            return View(model);
        }


        public ActionResult BuyTicket(int theaterId, int movieId)
        {
            

            var result = _movieService.ReserveTicket(theaterId, movieId);
            return View(result);
        }


        public ActionResult BuyMeTicket(int idMovie)
        {
            int userId = _userRepository.GetAll().FirstOrDefault(x => x.Username == _username).Id;
            //service vo movies tuka
            return View();
        }
  
    }
}