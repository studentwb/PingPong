using MediatR;
using Server.Domain.Entites;

namespace Server.Application.Games.Commands.SaveGame
{
    public class SaveGameCommand : IRequest<int>
    {
        public Game game { get; set; }
    }
}
