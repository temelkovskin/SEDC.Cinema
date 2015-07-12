using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;

namespace Cinema.Infrastrucutre.Repositories
{
    public class TheaterRepository : BaseRepository<Theater>, ITheaterRepository
    {
        public TheaterRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
