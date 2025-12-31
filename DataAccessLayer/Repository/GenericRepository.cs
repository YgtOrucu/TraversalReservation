using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly TraversalContext _traversalContext;

        private readonly DbSet<T> _object;

        public GenericRepository(TraversalContext traversalContext)
        {
            _traversalContext = traversalContext;
            _object = _traversalContext.Set<T>();
        }

        public List<T> GetAllList()
        {
            return _object.ToList();
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            _object.Add(entity);
            _traversalContext.SaveChanges();
        }

        public void Update(T entity)
        {
            var updateded = _traversalContext.Entry(entity);
            updateded.State = EntityState.Modified;
            _traversalContext.SaveChanges();
        }
    }
}
