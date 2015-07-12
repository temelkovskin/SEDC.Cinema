using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
