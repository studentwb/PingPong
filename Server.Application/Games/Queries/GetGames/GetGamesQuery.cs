using MediatR;
using Server.Domain.Entites;

namespace Server.Application.Games.Queries.GetGames
{
    public class GetGamesQuery : IRequest<IEnumerable<Game>>
    {
    }
}
