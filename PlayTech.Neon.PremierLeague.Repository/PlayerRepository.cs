namespace PlayTech.Neon.PremierLeague.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly Dictionary<string, IEnumerable<string>> TotalTeams = new Dictionary<string, IEnumerable<string>>();
    private readonly Dictionary<string, IEnumerable<string>> AllocatedPlayers = new Dictionary<string, IEnumerable<string>>();


    public PlayerRepository()
    { 
        TotalTeams.Add("Team1", new [] {"Player1", "Player2", "Player3", "Player4", "Player5", "Player6", "Player7", "Player8","Player9", "Player10"});
        TotalTeams.Add("Team2", new [] {"Player21", "Player22", "Player23", "Player24", "Player25", "Player26", "Player27", "Player28", "Player29", "Player20" });
        TotalTeams.Add("Team3", new [] {"Player31", "Player32", "Player33", "Player34", "Player35", "Player36", "Player37", "Player38", "Player39", "Player30" });
        TotalTeams.Add("Team4", new [] {"Player41", "Player42", "Player43", "Player44", "Player45", "Player46", "Player47", "Player48", "Player49", "Player40" });
        TotalTeams.Add("Team5", new [] {"Player51", "Player52", "Player53", "Player54", "Player55", "Player56", "Player57", "Player58", "Player59", "Player50" });
        TotalTeams.Add("Team6", new [] {"Player61", "Player62", "Player63", "Player64", "Player65", "Player66", "Player67", "Player68", "Player69", "Player60" });
        TotalTeams.Add("Team7", new [] {"Player71", "Player72", "Player73", "Player74", "Player75", "Player76", "Player77", "Player78", "Player79", "Player70" });
        TotalTeams.Add("Team8", new [] {"Player81", "Player82", "Player83", "Player84", "Player85", "Player86", "Player87", "Player88", "Player89", "Player80" });
        TotalTeams.Add("Team9", new [] {"Player91", "Player92", "Player93", "Player94", "Player95", "Player96", "Player97", "Player98", "Player99", "Player90" });
        TotalTeams.Add("Team10", new [] {"Player101", "Player102", "Player103", "Player104", "Player105", "Player106", "Player107", "Player108", "Player109", "Player1000" });

    }

    public IEnumerable<string> GetPlayersForUser(string userId)
    {
        return AllocatedPlayers.ContainsKey(userId) ? AllocatedPlayers[userId] : new List<string>();
    }

    public string GetTeamForPlayer(string playerId)
    {
        string parentTeam = null;
        foreach (var team in TotalTeams)
        {
            if (!team.Value.Contains(playerId)) continue;
            parentTeam = team.Key;
            break;
        }

        return parentTeam;
    }

    public void AddPlayerToUser(string userId, string playerId)
    {
        if (AllocatedPlayers.ContainsKey(userId))
        {
            var players = AllocatedPlayers[userId].ToList();
            players.Add(playerId);
            AllocatedPlayers[userId] = players;
        }
        else
        {
            AllocatedPlayers.Add(userId, new List<string>(){playerId});
        }
    }
}