namespace DataAccess
{
    public interface IRepository<TEntity>
    
    {
        int Add(TEntity entity);
        int Remove(TEntity entity);
        int Update(TEntity entity);
    }
}