
using Microsoft.EntityFrameworkCore;
using MVCproject.config;
using System.Linq.Expressions;

namespace MVCproject.Repository
{
    public class TRepository<T> : ITRepository<T> where T : class
    {
        public AppDbContext context;
        public readonly DbSet<T> _dbSet;

        public TRepository(AppDbContext _context)
        {
            context = _context;
            _dbSet = context.Set<T>();
        }
        public void Delete(int id)
        {
            var dept = GetById(id);
            context.Remove(dept);
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            // Dynamically include the specified related entities
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            context.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Update(obj);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        
    }
}
