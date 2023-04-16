using crosscuttingconcerns.PagingSorting;

namespace crosscuttingconcerns.Generics
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        #nullable enable
        public IQueryable<TEntity> GetAll();

        public Task<PaginatedList<TEntity>> GetList(int? pageNumber, string sortField, string sortOrder,
            int? pageSize);

        public Task<TEntity?> GetById(int id);
        public Task<TEntity?> GetByIdWithTracking(int id);
        public Task<TEntity?> Create(TEntity entity);
        public Task Update(TEntity entity);
        public Task Delete(int id);
        public Task AddList(List<TEntity> entityList);
    }

    public interface IEntity
    {
        int Id { get; set; }
    }
}