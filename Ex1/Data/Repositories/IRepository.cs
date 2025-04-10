namespace Ex1.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Delete(T entity);
        void Insert(T entity);
        void Update(T entity);
        Task<bool> SaveChangesAsync();
    }
}