namespace task.Repositories
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        bool Delete(int id);
        bool Update(TEntity entity);
        TEntity? Retrieve(int id);
        IEnumerable<TEntity> RetrieveAll();
    }
}
