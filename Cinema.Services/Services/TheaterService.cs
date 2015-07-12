using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Interfaces;
using Cinema.SharedModels.DTOs;

namespace Cinema.Services.Services
{
    public class TheaterService
    {
        private ITheaterRepository _theaterRepository;

        public TheaterService(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }

        public List<TheaterDTO> GetAllTheaters()
        {
            var result = _theaterRepository.GetAll();
            return result.Select(x => new TheaterDTO()
            {
                Id = x.Id,
                Name = x.TheaterName
            }).ToList();
        }
    }
}
