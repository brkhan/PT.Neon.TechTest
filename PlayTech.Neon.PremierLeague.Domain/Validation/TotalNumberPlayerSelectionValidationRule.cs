namespace PlayTech.Neon.PremierLeague.Domain.Validation;

public class TotalNumberPlayerSelectionValidationRule : IPlayerSelectionValidationRule
{
    public bool IsValid(string userId, string playerId)
    {
        return true;
    }
}