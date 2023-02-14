using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTech.Neon.PremierLeague.Domain.Services
{
    public interface IPlayerSelectionService
    {
        void AddPlayerSelection(string userId, string playerId);
        IEnumerable<string> GetPlayersForUser(string userId);
    }
}
