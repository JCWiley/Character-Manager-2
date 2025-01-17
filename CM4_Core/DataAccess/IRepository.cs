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
        public Task<T?> Add<T>() where T : class;
        public Task<T?> Add<T>(T entity) where T : class;
        public List<T> Get<T>() where T : class;
        public List<T> Get<T>(Func<T, bool> predicate) where T : class;
        public void Remove<T>(T entity) where T : class;
        public T? Update<T>(T entity) where T : class;
    }
}
