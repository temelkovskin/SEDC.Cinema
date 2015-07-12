using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Theater : BaseEntity
    {
        public string TheaterName { get; set; }
        public int NumberOfChairs { get; set; }

        public virtual ICollection<Movie> Movie { get; set; } 
    }
}
