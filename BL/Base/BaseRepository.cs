using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        #region Properties
        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }
        #endregion

        #region Constructor
        public BaseRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("dbContext");

            Context = context;
            DbSet = Context.Set<T>();
        }
        #endregion

        #region Get All Data Methods
        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<T> GetAllSorted<TKey>(Expression<Func<T, TKey>> sortingExpression)
        {
            return DbSet.OrderBy<T, TKey>(sortingExpression).ToList();
        }
        public IEnumerable<T> GetAllSortedDesc<TKey>(Expression<Func<T, TKey>> sortingExpression)
        {
            return DbSet.OrderByDescending<T, TKey>(sortingExpression).ToList();
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public bool GetAny(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;
            bool result = false;
            if (filter != null)
            {
                result = query.Any(filter);
            }
            return result;
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return DbSet.FirstOrDefault(filter);
        }

        #endregion

        #region Get one record
        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T GetById(long id)
        {
            return DbSet.Find(id);
        }

        #endregion

        #region CRUD Methods
        public virtual void Insert(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void InsertList(IEnumerable<T> entityList)
        {
            DbSet.AddRange(entityList);
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void UpdateList(IEnumerable<T> entityList)
        {
            foreach (T item in entityList)
            {
                Update(item);
            }
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }
        public virtual void DeleteList(IEnumerable<T> entityList)
        {
            foreach (T item in entityList)
            {
                Delete(item);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }
        #endregion
    }
}
