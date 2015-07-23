using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.SharedModels.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        [Display(Name = "Poster")]
        public string PictureUrl { get; set; }

        [Display(Name = "Short Description")]
        public string Description { get; set; }
        public string Acters { get; set; }

        [Display(Name = "In Cinemas from")]
        public DateTime StartingDate { get; set; }
        [Display(Name = "In Cinemas to")]
        public DateTime EndingDate { get; set; }

        [Display(Name = "Genre")]
        public string GenreDescription { get; set; }

        [Display(Name = "Theater")]
        public string TheaterDescription { get; set; }

        public int TheaterId { get; set; }
    }
}
