namespace generics.Interfaces
{
        public interface IRepository<TEntity, TKey>
        where TEntity : class, new()
        where TKey : struct
    {
        void Add(TKey id, TEntity entity);
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        void Remove(TKey id);
    }
        class InMemoryRepository<TEntity, TKey> :
    IRepository<TEntity, TKey>,
    IReadOnlyRepository<TEntity, TKey>,
    IWriteRepository<TEntity, TKey>
    where TEntity : class, new()
    where TKey : struct
{
    private Dictionary<TKey, TEntity> _storage = new();

    public void Add(TKey id, TEntity entity) => _storage[id] = entity;
    public TEntity Get(TKey id) => _storage.TryGetValue(id, out var entity) ? entity : null;
    public IEnumerable<TEntity> GetAll() => _storage.Values;
    public void Remove(TKey id) => _storage.Remove(id);
}

}
