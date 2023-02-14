using PlayTech.Neon.PremierLeague.Repository;

namespace PlayTech.Neon.PremierLeague.Domain.Validation;

public class SameClubPlayerSelectionValidationRule : IPlayerSelectionValidationRule
{
    private readonly IPlayerRepository _repository;

    public SameClubPlayerSelectionValidationRule(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public bool IsValid(string userId, string playerId)
    {
        var currentPlayers = _repository.GetPlayersForUser(userId);
        var teams = currentPlayers.Select(a => _repository.GetTeamForPlayer(a));

        var selectedPlayerTeam = _repository.GetTeamForPlayer(playerId);
        if (teams.All(a => !a.Equals(selectedPlayerTeam)))
        {
            return true;
        }

        else
        {
            var sameTeamPlayers = teams.Count(a => a.Equals(selectedPlayerTeam));
            return sameTeamPlayers <= 2;
        }
    }
}