using MediatR;
using Server.Domain.Entites;
using Server.Domain.Repositories;

namespace Server.Application.Games.Commands.SaveGame
{
    public class SaveGameCommandHander(IGamesRepository gamesRepository) : IRequestHandler<SaveGameCommand, int>
    {
        public async Task<int> Handle(SaveGameCommand request, CancellationToken cancellationToken)
        {

            int id = await gamesRepository.Create(request.game);
            return id;
        }
    }
}
