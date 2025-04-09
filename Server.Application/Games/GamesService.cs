using Server.Domain.Entites;
using Server.Domain.Repositories;

namespace Server.Application.Games
{
    internal class GamesService(IGamesRepository gamesRepository) : IGamesService
    {
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await gamesRepository.GetGamesAsync();
        }

        public async Task Post(Game game)
        {
            try
            {
                await gamesRepository.Create(game);
            }
            catch 
            {
                throw;
            }
        }
    }
}
