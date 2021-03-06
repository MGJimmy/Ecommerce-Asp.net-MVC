using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includeProperties = "");

        T GetById(int entityId);

        void Insert(T entity);
        void InsertList(IEnumerable<T> entity);

        void Update(T entity);
        void UpdateList(IEnumerable<T> entity);

        void Delete(T entity);
        void Delete(int entityId);
    }

}
