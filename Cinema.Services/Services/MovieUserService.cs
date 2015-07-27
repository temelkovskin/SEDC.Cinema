using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Infrastrucutre;
using Cinema.SharedModels.DTOs;

namespace Cinema.Services.Services
{
    public class MovieUserService
    {
        private IMovieUserRepository _movieUserRepository;
        private IMovieRepository _movieRepository;
        private IUserRepository _userRepository;

        public MovieUserService(IMovieUserRepository movieUserRepository, IMovieRepository movieRepository, IUserRepository userRepository)
        {
            _movieUserRepository = movieUserRepository;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public void UserBuysMovieTicket(int idMovie, string loggedUser)
        {
            var currentUser = _userRepository.GetAll().FirstOrDefault(x => x.Username == loggedUser).Id;

            var boughtTicket = new MovieUser()
            {
                Movie = _movieRepository.GetById(idMovie),
                Rating = 0,
                UserId = currentUser,
            };
            _movieUserRepository.Add(boughtTicket);
            _movieUserRepository.Save();
        }

        public List<UserMoviesDto> WatchedMovies(string loggedUser)
        {
            var currentUser = _userRepository.GetAll().FirstOrDefault(x => x.Username == loggedUser).Id;
            var userMovies = _movieUserRepository.GetAll().Where(x => x.UserId == currentUser);
            return userMovies.Select(x => new UserMoviesDto()
            {
                MovieId = x.MovieId,
                MovieTitle = x.Movie.Title,
                Rating = x.Rating,
                UserId = currentUser

            }).ToList();

        }

        public void RateTheMovie(UserMoviesDto dto)
        {
            var result =
                _movieUserRepository.GetAll().FirstOrDefault(x => x.UserId == dto.UserId && x.MovieId == dto.MovieId);

            if (result != null)
            {
                var userMovie = new MovieUser()
                {
                    MovieId = dto.UserId,
                    Rating = dto.Rating,
                    UserId = dto.UserId,
                };


                _movieUserRepository.UpdateRating(userMovie);
                _movieUserRepository.Save();
            }            
           
        }
        
    }
}
