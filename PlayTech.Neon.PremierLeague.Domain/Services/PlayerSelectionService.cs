using System.ComponentModel.DataAnnotations;
using PlayTech.Neon.PremierLeague.Domain.Validation;
using PlayTech.Neon.PremierLeague.Repository;

namespace PlayTech.Neon.PremierLeague.Domain.Services;

public class PlayerSelectionService : IPlayerSelectionService
{
    private readonly IEnumerable<IPlayerSelectionValidationRule> _validationRules;
    private readonly IPlayerRepository _repository;

    public PlayerSelectionService(IEnumerable<IPlayerSelectionValidationRule> validationRules, IPlayerRepository repository)
    {
        _validationRules = validationRules;
        _repository = repository;
    }
    public void AddPlayerSelection(string userId, string playerId)
    {
        IList<bool> valid = _validationRules.Select(rule => rule.IsValid(userId, playerId)).ToList();

        if (valid.All(a => a == true))
        {
            _repository.AddPlayerToUser(userId, playerId);
        }

        else throw new ValidationException();
    }

    public IEnumerable<string> GetPlayersForUser(string userId)
    {
        var players = _repository.GetPlayersForUser(userId);
        return players;
    }
}