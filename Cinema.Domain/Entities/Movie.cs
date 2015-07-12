using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;

namespace Cinema.Domain
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string Acters { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }

        //each movie can be shown in differnt time
        public virtual ICollection<TimeInterval> TimeIntervals { get; set; } 

        //each movie can have only one Genre :)
        public virtual Genre Genre { get; set; } 

        //each movie can be only in one Theater :)
        public virtual Theater Theater { get; set; }

        //Each user can watch more then one movie
        public virtual ICollection<MovieUser> MovieUsers { get; set; } 

    }
}
