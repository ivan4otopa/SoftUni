namespace News.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Find(int id);

        T Add(T entity);

        void Update(int id, T entity);

        void Delete(int id);

        void SaveChanges();
    }
}
