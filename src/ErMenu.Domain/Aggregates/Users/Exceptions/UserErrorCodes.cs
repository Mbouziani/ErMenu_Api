namespace ErMenu.Domain.Aggregates.Users.Exceptions;

public static class UserErrorCodes
{
    public const string EmailAlreadyExists = "USER_EMAIL_ALREADY_EXISTS";
    public const string PhoneAlreadyExists = "USER_PHONE_ALREADY_EXISTS";

    public const string UserNotFound = "USER_NOT_FOUND";
    public const string InvalidCredentials = "USER_INVALID_CREDENTIALS";
    public const string Unauthorized = "USER_UNAUTHORIZED";

    public const string InvalidRole = "USER_INVALID_ROLE";
    public const string FirstNameRequired = "USER_FIRST_NAME_REQUIRED";
    public const string LastNameRequired = "USER_LAST_NAME_REQUIRED";
    public const string ImageRequired = "USER_AVATAR_REQUIRED";
    public const string ResetTokenRequired = "USER_RESET_TOKEN_REQUIRED";
    public const string OtpCodeRequired = "USER_OTP_CODE_REQUIRED";
    public const string InvalidOtp = "USER_INVALID_OTP";
    public const string SamePassword = "USER_SAME_PASSWORD";
    public const string PasswordRequired = "USER_PASSWORD_REQUIRED";
    public const string DeviceNameRequired = "USER_DEVICE_NAME_REQUIRED";
    public const string IpAddressRequired = "USER_IP_ADDRESS_REQUIRED";


    public const string InvalidPassword = "USER_INVALID_PASSWORD";
    public const string RefreshTokenRequired = "USER_REFRESH_TOKEN_REQUIRED";
    public const string UnauthorizedSelfAffect = "USER_UNAUTHORIZED_SELF_AFFECT";
    public const string SameRole = "USER_SAME_ROLE";

    public const string UserAlreadyExists = "USER_ALREADY_EXISTS";
    public const string UserIdRequired = "USER_ID_REQUIRED";

    public const string UserAlreadyDeleted = "USER_ALREADY_DELETED";
    public const string UserAlreadyLocked = "USER_ALREADY_LOCKED";
    public const string UserIsInactive = "USER_IS_INACTIVE";
    public const string MissingUserIdClaim = "USER_MISSING_USER_ID_CLAIM";
    public const string MissingBranchIdClaim = "USER_MISSING_BRANCH_ID_CLAIM";
    public const string MissingRoleClaim = "USER_MISSING_ROLE_CLAIM";
    public const string BadAdminSeeding = "USER_BAD_ADMIN_SEEDING";
    public const string ProblemOccurredWhileInsertingUserSession = "USER_PROBLEM_OCCURRED_WHILE_INSERTING_USER_SESSION";
    public const string YourTrialPeriodHasExpired = "YOUR_TRIAL_PERIOD_HAS_EXPIRED";


    public const string AccountUnavailable = "USER_ACCOUNT_UNAVAILABLE";
    public const string AccountInactive = "USER_ACCOUNT_INACTIVE";
    public const string AccountLocked = "USER_ACCOUNT_LOCKED";
    public const string TokenInvalid = "USER_TOKEN_INVALID";
    public const string RefreshTokenMissing = "USER_REFRESH_TOKEN_MISSING";
    public const string YouHaveNoPermission = "USER_YOU_HAVE_NO_PERMISSION";
    public const string ResetPasswordInvalid = "USER_RESET_PASSWORD_INVALID";
    public const string InvalidLoginCredentials = "USER_INVALID_LOGIN_CREDENTIALS";

}