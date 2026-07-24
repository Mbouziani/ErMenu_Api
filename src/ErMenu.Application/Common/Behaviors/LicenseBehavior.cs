using ErMenu.Domain.Aggregates.Users.Exceptions;

namespace ErMenu.Application.Common.Behaviors;


public static class LicenseBehavior
{
    private static readonly DateTime TrialEnds =
        new(2026, 8, 5, 0, 0, 0, DateTimeKind.Utc);

    public static void EnsureLicense()
    {
        if (DateTime.UtcNow >= TrialEnds)
        {
            throw UserExceptions.YourTrialPeriodHasExpired();
        }
    }
}