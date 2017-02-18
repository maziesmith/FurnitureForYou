using FFY.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace FFY.Data
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        public GenericRepository(IFFYContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context cannot be null.");
            }

            this.Context = context;
            this.Set = this.Context.Set<T>();
        }

        public IDbSet<T> Set { get; set; }

        public IFFYContext Context { get; set; }

        public T GetById(object id)
        {
            return this.Set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetAll(null);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.GetAll<object>(filterExpression, null);
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression)
        {
            return this.GetAll<T1, T>(filterExpression, sortExpression, null);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, 
            Expression<Func<T, T1>> sortExpression, 
            Expression<Func<T, T2>> selectExpression)
        {
            IQueryable<T> result = this.Set;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if(sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }

            return result.OfType<T2>().ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression, int? skip = null, int? take = null)
        {
            IQueryable<T> result = this.Set;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (skip != null)
            {
                result = result.Skip(skip.Value);
            }

            if (take != null)
            {
                result = result.Take(take.Value);
            }

            return result.ToList();
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, T1>> sortExpression, int? skip = null, int? take = null)
        {
            IQueryable<T> result = this.Set;

            if (sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (skip != null)
            {
                result = result.Skip(skip.Value);
            }

            if (take != null)
            {
                result = result.Take(take.Value);
            }

            return result.ToList();
        }

        public void Add(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set.Attach(entity);
            }

            return entry;
        }
    }
}
