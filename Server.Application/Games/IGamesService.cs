using Server.Domain.Entites;

namespace Server.Application.Games
{
    public interface IGamesService
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task Post(Game game);
    }
}
