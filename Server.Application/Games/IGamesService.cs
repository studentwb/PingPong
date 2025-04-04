using Server.Domain.Entites;

namespace Server.Application.Games
{
    public interface IGamesService
    {
        Task<IEnumerable<Game>> GetAllGames();
        Task Post(Game game);
    }
}
