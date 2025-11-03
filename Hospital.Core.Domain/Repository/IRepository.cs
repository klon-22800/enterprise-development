namespace Hospital.Core.Domain.Repository;


public interface IRepository<T> where T : class
{

    public Task<Guid> CreateAsync(T entity);

    public Task<List<T>> GetAllAsync();

    public Task<T?> GetByIdAsync(Guid id);

    public Task<T?> UpdateAsync(Guid id, T entity);

    public Task<bool> DeleteAsync(Guid id);
}
