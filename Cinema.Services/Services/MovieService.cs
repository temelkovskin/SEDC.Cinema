﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.SharedModels;

namespace Cinema.Services.Services
{
    public class MovieService
    {
        private IMovieRepository _movieRepository;
        private ITheaterRepository _theaterRepository;
        private IGenreRepository _genreRepository;
        private ITimeIntervalRepository _timeIntervalRepository;

        public MovieService(IMovieRepository movieRepository, ITheaterRepository theaterRepository,
            IGenreRepository genreRepository, ITimeIntervalRepository timeIntervalRepository)
        {
            _movieRepository = movieRepository;
            _theaterRepository = theaterRepository;
            _genreRepository = genreRepository;
            _timeIntervalRepository = timeIntervalRepository;
        }

        public void AddMovie(Movie_GenreTheaterDTO model)
        {
            var intervals = new List<TimeInterval>();
            foreach (string item in model.TimeIntervalsId)
            {
                var currentId = Int32.Parse(item);
                var tempInterval = _timeIntervalRepository.GetById(currentId);
                intervals.Add(tempInterval);
            }

            Movie movie = new Movie()
            {
                Title = model.Movie.Title,
                PictureUrl = model.Movie.PictureUrl,
                Description = model.Movie.Description,
                StartingDate = model.Movie.StartingDate,
                EndingDate = model.Movie.EndingDate,

                Theater = _theaterRepository.GetById(model.TheaterId),
                Genre = _genreRepository.GetById(model.GenreId),
                TimeIntervals = intervals
            };
            _movieRepository.Add(movie);
            _movieRepository.Save();
        }


    }
}
