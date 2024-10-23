using System.Linq.Expressions;

namespace MVCproject.Repository
{
    public interface ITRepository<T>
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);//string includes=null)
        List<T> GetAll();
        T GetById(int id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(int id);

        void Save();
        Task SaveAsync();
       // Task<T> UpdateAsync(T obj);
    }
}
