using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VezeetaAPI.Core.Models;

namespace VezeetaAPI.Core.Repositories
{
    public interface IbaseRepository<T> where T : class 
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();    

        T Find(Expression<Func<T,bool>> match);

        T Add (T entity);

        T Update (T entity);    

        void Delete (T entity);

        void DeleteById(int id);
        List<Doctors> GetTopTenDoctors();
        List<Specalization> GetTopFiveSpecalizations();
        IEnumerable<T> GetAllByPage(int page = 1, int pageSize = 10);



    }

}
