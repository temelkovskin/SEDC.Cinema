using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IBaseRepository <TEntity>
        where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Save();
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void Delete(int id);

        void Update(TEntity entity);
    }
}
