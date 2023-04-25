using WebParking.Data.Data;

namespace WebParking.Data.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly ParkingContext context;
        public BaseRepository(ParkingContext context)
        {
            this.context = context;
        }

        public T Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            Save();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            return await Task.Run(() => Delete(entity));
        }

        public IEnumerable<T> GetAll()
        {
            return GetQuery();
        }

        public IQueryable<T> GetQuery()
        {
            return context.Set<T>();
        }

        public T Insert(T entity)
        {
            context.Set<T>().Add(entity);
            Save();

            return entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            return await Task.Run(() => Insert(entity));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public T Update(T entity)
        {
            context.Set<T>().Update(entity);
            Save();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await Task.Run(() => Update(entity));
        }
    }
}