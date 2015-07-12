using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Cinema.Domain;
using Cinema.Domain.Entities;

namespace Cinema.SharedModels
{
    public class Movie_GenreTheaterDTO
    {
        public Movie Movie { get; set; }

        public int GenreId { get; set; }
        public List<SelectListItem> Genres { get; set; }

        public int TheaterId { get; set; }
        public List<SelectListItem> Theater { get; set; }


        //source --> http://mvccbl.com/Documentation
        //  Install-Package MvcCheckBoxList 
        public string[] TimeIntervalsId { get; set; }
        public IList<TimeInterval> TimesList { get; set; }
        public IList<TimeInterval> SelectedTimeIntervals { get; set; }  
        public IEnumerable<TimeInterval> TimeIntervals { get; set; } 
    }   
}
