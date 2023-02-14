namespace PlayTech.Neon.PremierLeague.Domain.Validation;

public class MaximumBudgetPlayerSelectionValidationRule : IPlayerSelectionValidationRule
{
    private readonly int _maximumBudget = 100000000;

    public bool IsValid(string userId, string playerId)
    {
        return true;
    }
}