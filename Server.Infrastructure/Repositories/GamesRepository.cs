using Microsoft.EntityFrameworkCore;
using Server.Domain.Entites;
using Server.Domain.Repositories;
using Server.Infrastructure.Persistence;

namespace Server.Infrastructure.Repositories
{
    internal class GamesRepository(ApplicationDbContext dbContext) : IGamesRepository
    {
        public async Task Create(Game game)
        {
                dbContext.Add(game);
                await dbContext.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Game>> GetGamesAsync()
        {
            var games= await dbContext.Games.ToListAsync();
            return games;
        }
    }
}
