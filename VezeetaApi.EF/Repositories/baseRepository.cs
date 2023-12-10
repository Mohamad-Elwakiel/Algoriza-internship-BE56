using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VezeetaAPI.Core.Models;
using VezeetaAPI.Core.Repositories;

namespace VezeetaApi.EF.Repositories
{
    public class baseRepository<T> : IbaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public baseRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public T Add(T entity)
        {
            _context.Add(entity);   
            _context.SaveChanges(); 
            return entity;  
        }
     

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);  
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void DeleteById(int id) 
        {
            var deletedUser = _context.Set<T>().Find(id);
            if (deletedUser != null) {
                
                _context.Remove(deletedUser);   
            }

        }
        public List<Doctors> GetTopTenDoctors()
        {
            var top =  (from d in _context.doctors
                      orderby d.Requests
                      select d).Take(10).ToList();
            return top;
            
        }
        public List<Specalization> GetTopFiveSpecalizations() 
        {
            var topSpec = (from s in _context.specalizations
                           orderby s.Doctors
                           select s).Take(5).ToList();
            return topSpec; 
        }
      
        public IEnumerable<T> GetAllByPage(int page = 1, int pageSize=10)
        {
            
            var result = _context.Set<T>().ToList();
            return result.Skip(page-1*pageSize).Take(pageSize).ToList();
        }
    }
}
