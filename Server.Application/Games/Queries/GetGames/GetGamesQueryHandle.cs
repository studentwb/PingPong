using MediatR;
using Server.Domain.Entites;
using Server.Domain.Repositories;

namespace Server.Application.Games.Queries.GetGames
{
    public class GetGamesQueryHandle(IGamesRepository gamesRepository) : IRequestHandler<GetGamesQuery, IEnumerable<Game>>
    {
        public async Task<IEnumerable<Game>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            return await gamesRepository.GetGamesAsync();
        }
    }
}
