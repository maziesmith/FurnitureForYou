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
        public GenericRepository(IFFYContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Context cannot be null.");
            }

            this.Context = dbContext;
            this.Set = this.Context.Set<T>();
        }

        protected IDbSet<T> Set { get; set; }

        protected IFFYContext Context { get; set; }

        public T GetById(object id)
        {
            return this.Set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.Set.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.Set
                .Where(filterExpression)
                .ToList();
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression)
        {
            return this.Set
                .Where(filterExpression)
                .OrderBy(sortExpression)
                .ToList();
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression)
        {
            return this.Set
                 .Where(filterExpression)
                 .OrderBy(sortExpression)
                 .Select(selectExpression)
                 .ToList();
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
