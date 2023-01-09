using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Core
{
    public interface IBaseRepository<T> where T : class
    {
        public List<T> List();
        public T Find(int id);
        public T Find(int id, int id2);
        public bool Update(T entity);
        public bool Delete(int id);
        public bool Delete(int id, int id2);
        public bool Add(T entity);
        public DbSet<T> Set();
        //public void Save();
    }
}
