using CM4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.DataAccess
{
    public interface IRepository
    {
        public Task<T?> Add<T>() where T : ModelBaseClass;
        public Task<T?> Add<T>(T entity) where T : ModelBaseClass;
        public List<T> Get<T>() where T : ModelBaseClass;
        public List<T> Get<T>(Func<T, bool> predicate) where T : ModelBaseClass;
        public T? Get<T>(Guid id) where T : ModelBaseClass;
        public void Remove<T>(T entity) where T : ModelBaseClass;
        public T? Update<T>(T entity) where T : ModelBaseClass;
        public void AddRelationship<P, C>(P parent, C child) where P : ModelBaseClass where C : ModelBaseClass;
    }
}
