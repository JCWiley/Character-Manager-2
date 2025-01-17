using CM4_Core.DataAccess;
using CM4_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CM4_DataAccess.DBV1
{
    public class Repository : IRepository
    {
        DataAccessV1 _DA;

        public Repository(DataAccessV1 DA)
        {
            _DA = DA;
        }

        public async Task<T?> Add<T>() where T : class
        {
            T temp = (T)Activator.CreateInstance(typeof(T), []);
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    T result = (await Context.AddAsync<T>(temp)).Entity;
                    await Context.SaveChangesAsync();
                    return result;
                }
            }
            return null;

        }

        public async Task<T?> Add<T>(T entity) where T : class
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    T result = (await Context.AddAsync<T>(entity)).Entity;
                    await Context.SaveChangesAsync();
                    return result;
                }
            }
            return null;
        }

        public List<T> Get<T>() where T : class
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    return Context.Set<T>().ToList();
                }
            }
            return new List<T>();
        }

        public List<T> Get<T>(Func<T, bool> predicate) where T : class
        {
            return Get<T>().Where(predicate).ToList();
        }

        public void Remove<T>(T entity) where T : class
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    Context.Set<T>().Remove(entity);
                    Context.SaveChanges();
                }
            }
        }

        public T? Update<T>(T entity) where T : class
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    T result = Context.Set<T>().Update(entity).Entity;
                    Context.SaveChanges();
                    return result;
                }
            }
            return (T)Activator.CreateInstance(typeof(T), []);
        }
    }
}
