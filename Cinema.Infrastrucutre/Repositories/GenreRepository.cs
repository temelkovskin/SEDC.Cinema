using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;

namespace Cinema.Infrastrucutre.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DatabaseContext context) 
            : base(context)
        {
        }
    }
}
