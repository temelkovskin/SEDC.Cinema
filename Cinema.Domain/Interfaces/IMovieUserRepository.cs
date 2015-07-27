using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IMovieUserRepository : IBaseRepository<MovieUser>
    {
        void UpdateRating(MovieUser entity);
    }
}