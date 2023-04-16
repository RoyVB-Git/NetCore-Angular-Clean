using dal.DataObjects;
using dal.Repositories;
using logic.Dtos;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace logic.Services
{
    public interface IGameService
    {
        Task<GameDto?> GetById(int id);
        Task<List<GameDto>> GetAll();
    }

    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameDto?> GetById(int id)
        {
            var game = await _gameRepository.GetById(id).ConfigureAwait(false);
            if (game == null)
            {
                return null;
            }

            return GameMapper(game);
        }

        public async Task<List<GameDto>> GetAll()
        {
            var games = await _gameRepository
                .GetAll()
                .Include(g => g.GameType)
                .ToListAsync()
                .ConfigureAwait(false);
            var gameDtos = new List<GameDto>();
            if (!games.Any())
            {
                return gameDtos;
            }

            foreach (var game in games)
            {
                gameDtos.Add(GameMapper(game));
            }
            return gameDtos;
        }

        private GameDto GameMapper(Game game)
        {
            return new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                GameTypeId = game.GameTypeId,
                GameType = new GameTypeDto
                {
                    Id = game.GameType.Id,
                    Description = game.GameType.Description
                }
            };
        }
    }
}
