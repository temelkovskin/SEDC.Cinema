using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.SharedModels.DTOs;

namespace Cinema.Services.Services
{
    public class GenreService
    {
        private IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public List<GenreDTO> GetAllGenres()
        {
            var result = _genreRepository.GetAll();
            return result.Select(x => new GenreDTO()
            {
                Id = x.Id,
                Description = x.GenreDescription
            }).ToList();
        }

    }
}
