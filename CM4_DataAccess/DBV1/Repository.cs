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

        public async Task<T?> Add<T>() where T : ModelBaseClass
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

        public async Task<T?> Add<T>(T entity) where T : ModelBaseClass
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

        public List<T> Get<T>() where T : ModelBaseClass
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

        public List<T> Get<T>(Func<T, bool> predicate) where T : ModelBaseClass
        {
            return Get<T>().Where(predicate).ToList();
        }

        public T? Get<T>(Guid id) where T : ModelBaseClass
        {
            T? Result = null;
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    Result = Context.Set<T>().FindAsync(id).Result;
                }
            }
            return Result;
        }

        public void Remove<T>(T entity) where T : ModelBaseClass
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

        public T? Update<T>(T entity) where T : ModelBaseClass
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    Context.Attach(entity);
                    Context.Entry(entity).State = EntityState.Modified;
                    T result = Context.Set<T>().Update(entity).Entity;
                    Context.SaveChanges();
                    return result;
                }
            }
            return (T)Activator.CreateInstance(typeof(T), []);
        }
        public void AddRelationship<P, C>(P parent, C child) where P : ModelBaseClass where C : ModelBaseClass
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    Context.Attach(parent);
                    Context.Attach(child);
                    switch (parent)
                    {
                        case Organization parentOrg:
                            switch (child)
                            {
                                case Organization subOrg:
                                    parentOrg.Child_Organizations.Add(subOrg.ID);
                                    subOrg.Parent_Organizations.Add(parentOrg.ID);
                                    break;
                                case Character character:
                                    parentOrg.Child_Characters.Add(character.ID);
                                    character.Parent_Organizations.Add(parentOrg.ID);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;

                    }
                    Context.Set<P>().Update(parent);
                    Context.Set<C>().Update(child);
                    Context.SaveChanges();
                }

            }
        }
    }
}
