using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class MovieUser : BaseEntity
    {
        [Key, Column(Order = 0)]
        public int MovieId { get; set; }
        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        public int Rating { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }

    }
}
