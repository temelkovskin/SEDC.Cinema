using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.SharedModels.DTOs
{
    public class TheaterMovieDto
    {
        public int TheaterId { get; set; }
        public int NumberChairs { get; set; }

        public int MovieId { get; set; }
        public string MovieTitle { get; set; }

        public int UserId { get; set; }
    }
}
