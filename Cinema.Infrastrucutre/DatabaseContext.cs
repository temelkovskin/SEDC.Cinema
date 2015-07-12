using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain;
using Cinema.Domain.Entities;

namespace Cinema.Infrastrucutre
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            
        }


        public DatabaseContext(string cnn)
            : base(cnn)
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieUser> MovieUsers { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<TimeInterval> TimeIntervals { get; set; }

        public System.Data.Entity.DbSet<Cinema.Domain.Entities.User> Users { get; set; }

       

        //public System.Data.Entity.DbSet<Cinema.SharedModels.GenreDTO> GenreDTOes { get; set; } 


    }
    
}
