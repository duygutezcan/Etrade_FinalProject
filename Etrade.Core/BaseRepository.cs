using Etrade.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Core
{
    public class BaseRepository<T> where T : class
    {
        TradeContext _db;

        public BaseRepository(TradeContext db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {

            try
            {
                Set().Add(entity);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {

            try
            {
                Set().Remove(Find(id));

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int Id, int Id2)
        {

            try
            {
                Set().Remove(Find(Id, Id2));

                return true;
            }
            catch
            {
                return false;
            }
        }



        public T Find(int Id)
        {
            return Set().Find(Id);
        }
        public T Find(int Id, int Id2)
        {
            return Set().Find(Id, Id2);
        }


        public List<T> List()
        {
            // _db.Set<T>().ToList(); bunu yazmamak için set dedik
            return Set().ToList();
        }



        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
