using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Domain;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
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
        private MovieUserRepository _movieUserRepository;
        private MovieUserService _movieUserService;
        private DatabaseContext _db;

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
            var movieUserRepository = new MovieUserRepository(dbContext);
             _db = dbContext;
            

            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _theaterRepository = theaterRepository;
            _timeIntervalRepository = timeIntervalRepository;
             _userRepository = userRepository;
             _movieUserRepository = movieUserRepository;

            _movieService = new MovieService(movieRepository, theaterRepository, 
                _genreRepository, timeIntervalRepository);
            _genreService = new GenreService(genreRepository);
            _theaterService = new TheaterService(theaterRepository);
            _movieUserService = new MovieUserService(movieUserRepository, movieRepository, userRepository);
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
            _movieUserService.UserBuysMovieTicket(idMovie, _username);
            return Content("<script language='javascript' type='text/javascript'>alert('Thanks the ticket has been bought. Now you can rate the movie');</script>");
            
        }

        public ActionResult WatchedMovies(string username)
        {
            _username = username;
            var model = _movieUserService.WatchedMovies(_username);
            return View(model);
        }

        public ActionResult Rate(int idMovie, int idUser)
        {

            var result =
                _movieUserService.WatchedMovies(_username)
                    .FirstOrDefault(x => x.UserId == idUser && x.MovieId == idMovie);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rate(UserMoviesDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _db.MovieUsers.FirstOrDefault(x => x.MovieId == dto.MovieId && x.UserId == dto.UserId);
                result.Rating = dto.Rating;

                _db.Entry(result).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("WatchedMovies", new { username = _username });
            }
            return View(dto);

        }
  
    }
}