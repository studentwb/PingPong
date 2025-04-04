using Server.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Repositories
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task Create(Game game);
    }
}
