using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.SharedModels.DTOs
{
    public class UserMoviesDto
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int MovieId { get; set; }

        [Display(Name = "Movie")]
        public string MovieTitle { get; set; }
        

        [Range(0, 5, ErrorMessage = "Rating can be between 1 - 5")]
        public int Rating { get; set; }
    }
}
