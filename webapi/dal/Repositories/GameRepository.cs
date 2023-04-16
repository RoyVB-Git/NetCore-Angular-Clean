using crosscuttingconcerns.Generics;
using crosscuttingconcerns.PagingSorting;
using dal.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace dal.Repositories
{
    public interface IGameRepository
    {
        Task<Game?> GetById(int id);
        IQueryable<Game> GetAll();

        Task<PaginatedList<Game>> GetList(
            int? pageNumber,
            string sortField,
            string sortOrder,
            int? pageSize);

        Task<Game?> GetByIdWithTracking(int id);
        Task<Game?> Create(Game entity);
        Task Update(Game entity);
        Task UpdateBulk(List<Game> entity);
        Task Delete(int id);
        Task DeleteBulk(List<Game> entity);
        Task AddList(List<Game> entityList);
    }

    public class GameRepository: GenericRepository<Game>, IGameRepository
    {
        public GameRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
        }

        public override async Task<Game?> GetById(int id)
        {
            return await GetAll()
                .Include(g => g.GameType)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }
    }
}
