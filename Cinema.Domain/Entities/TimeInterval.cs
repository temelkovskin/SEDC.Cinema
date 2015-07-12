using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class TimeInterval : BaseEntity
    {
        public int Hour { get; set; }
        public int Minutes { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
