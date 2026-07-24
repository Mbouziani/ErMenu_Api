using ErMenu.Domain.Common.Exceptions.Base;

namespace ErMenu.Domain.Aggregates.Users.Exceptions;

public static class UserExceptions
{
    public static UnauthorizedException RefreshTokenMissing()
        => new(UserErrorCodes.RefreshTokenMissing, "Refresh token is missing");

    public static UnauthorizedException TokenInvalid()
        => new(UserErrorCodes.TokenInvalid, "Token is invalid or expired");
    public static UnauthorizedException MissingUserIdClaim()
    => new(UserErrorCodes.MissingUserIdClaim, "User identity is missing (UserId claim not found)");

    public static UnauthorizedException MissingBranchIdClaim()
        => new(UserErrorCodes.MissingBranchIdClaim, "User branch is missing (BranchId claim not found)");

    public static UnauthorizedException MissingRoleClaim()
        => new(UserErrorCodes.MissingRoleClaim, "User role is missing or invalid");



    public static UnauthorizedException ProblemOccurredWhileInsertingUserSession()
       => new(UserErrorCodes.ProblemOccurredWhileInsertingUserSession, "Problem occurred while inserting user session");

    public static UnauthorizedException YourTrialPeriodHasExpired()
        => new(UserErrorCodes.YourTrialPeriodHasExpired, "The application is currently unavailable. Please contact your service provider for assistance.");




    public static ForbiddenException AccountUnavailable()
        => new(UserErrorCodes.AccountUnavailable, "Account unavailable");

    public static ForbiddenException AccountLocked()
        => new(UserErrorCodes.AccountLocked, "Your account is locked");

    public static ForbiddenException AccountInactive()
        => new(UserErrorCodes.AccountInactive, "Your account is inactive");




    public static BadRequestException InvalidLoginCredentials()
    => new(UserErrorCodes.InvalidLoginCredentials, "Invalid Number Or Password");

    public static BadRequestException YouHaveNoPermission()
        => new(UserErrorCodes.YouHaveNoPermission, "You do not have permission to perform this action");

    public static BadRequestException ResetPasswordInvalid()
        => new(UserErrorCodes.ResetPasswordInvalid, "Reset token is invalid or expired");

    public static BadRequestException InvalidOtp()
    => new(UserErrorCodes.InvalidOtp, "OTP is invalid or expired");

    public static BadRequestException SamePassword()
        => new(UserErrorCodes.SamePassword, "New password cannot be the same as old password");

    public static BadRequestException InvalidPassword()
        => new(UserErrorCodes.InvalidPassword, "Invalid password format");

    public static BadRequestException BadAdminSeeding()
=> new(UserErrorCodes.BadAdminSeeding, "Bad admin seeding");




    public static NotFoundException UserNotFound()
        => new(UserErrorCodes.UserNotFound, "User not found");

    public static ConflictException EmailAlreadyExists()
        => new(UserErrorCodes.EmailAlreadyExists, "Email already exists");

    public static ConflictException PhoneAlreadyExists()
        => new(UserErrorCodes.PhoneAlreadyExists, "Phone already exists");

    public static ConflictException SameRole()
        => new(UserErrorCodes.SameRole, "User already has this role");

    public static ConflictException UserAlreadyDeleted()
        => new(UserErrorCodes.UserAlreadyDeleted, "User already deleted");

    public static ConflictException UserAlreadyLocked()
        => new(UserErrorCodes.UserAlreadyLocked, "User already locked");

    public static ConflictException UserIsInactive()
        => new(UserErrorCodes.UserIsInactive, "User is inactive");


}