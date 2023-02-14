namespace PlayTech.Neon.PremierLeague.Repository
{
    public interface IPlayerRepository
    {
        IEnumerable<string> GetPlayersForUser(string userId);

        string GetTeamForPlayer(string playerId);

        void AddPlayerToUser(string userId, string playerId);
    }
}