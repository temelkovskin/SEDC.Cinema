using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain;
using Cinema.Domain.Interfaces;

namespace Cinema.Infrastrucutre.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
