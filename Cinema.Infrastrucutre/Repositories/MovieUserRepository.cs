using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;

namespace Cinema.Infrastrucutre.Repositories
{
    public class MovieUserRepository : BaseRepository<MovieUser>, IMovieUserRepository
    {
        public MovieUserRepository(DatabaseContext context) 
            : base(context)
        {

        }

        public void UpdateRating(MovieUser entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
