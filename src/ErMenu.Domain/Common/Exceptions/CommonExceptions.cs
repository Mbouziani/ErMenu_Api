using ErMenu.Domain.Common.Exceptions.Base;

namespace ErMenu.Domain.Common.Exceptions;


public static class CommonExceptions
{
    

    #region Phone number related exceptions

    public static BadRequestException PhoneNumberRequired()
        => new(CommonErrorCodes.PhoneNumberRequired, "Phone number is required");

    public static BadRequestException InvalidPhoneNumber()
        => new(CommonErrorCodes.InvalidPhoneNumber, "Invalid phone number");

    public static BadRequestException PhoneNumberCountryCodeRequired()
        => new(CommonErrorCodes.PhoneNumberCountryCodeRequired, "Phone number country code is required");

    public static BadRequestException PhoneMustStartWithPlusAndCountryCode()
        => new(CommonErrorCodes.PhoneMustStartWithPlusAndCountryCode, "Phone number must start with plus and country code");

    public static BadRequestException PhoneMustContainDigitsOnly()
        => new(CommonErrorCodes.PhoneMustContainDigitsOnly, "Phone number must contain digits only");

    public static BadRequestException InvalidSaudiNumber()
        => new(CommonErrorCodes.InvalidSaudiNumber, "Invalid Saudi phone number");

    public static BadRequestException InvalidEgyptNumber()
        => new(CommonErrorCodes.InvalidEgyptNumber, "Invalid Egypt phone number");

    public static BadRequestException InvalidMoroccoNumber()
        => new(CommonErrorCodes.InvalidMoroccoNumber, "Invalid Morocco phone number");

    public static BadRequestException InvalidYemenNumber()
        => new(CommonErrorCodes.InvalidYemenNumber, "Invalid Yemen phone number");

    public static BadRequestException UnsupportedCountryCode()
        => new(CommonErrorCodes.UnsupportedCountryCode, "Unsupported country code");

    #endregion

    #region Email related exceptions; 

    public static BadRequestException EmailRequired()
        => new(CommonErrorCodes.EmailRequired, "Email is required");

    public static BadRequestException InvalidEmailFormat()
        => new(CommonErrorCodes.InvalidEmailFormat, "Invalid email format");

    #endregion

    #region Full name related exceptions

    public static BadRequestException FullNameRequired()
   => new(CommonErrorCodes.FullNameRequired, "Full name is required");

    public static BadRequestException InvalidFullName()
   => new(CommonErrorCodes.InvalidFullName, "Invalid full name");

    public static BadRequestException FirstNameRequired()
        => new(CommonErrorCodes.FirstNameRequired, "First name is required");

    public static BadRequestException InvalidFirstName()
      => new(CommonErrorCodes.InvalidFirstName, "Invalid first name");

    public static BadRequestException LastNameRequired()
        => new(CommonErrorCodes.LastNameRequired, "Last name is required");

    public static BadRequestException InvalidLastName()
        => new(CommonErrorCodes.InvalidLastName, "Invalid last name");
    #endregion

    #region Soft delete related error codes
    public static ConflictException EntityAlreadyDeleted()
        => new(CommonErrorCodes.EntityAlreadyDeleted, "Entity is already deleted");

    public static ConflictException EntityNotDeleted()
        => new(CommonErrorCodes.EntityNotDeleted, "Entity is not deleted");

    public static ConflictException EntityAlreadyExists()
        => new(CommonErrorCodes.EntityAlreadyExists, "Entity already exists");

    public static NotFoundException EntityNotFound()
        => new(CommonErrorCodes.EntityNotFound, "Entity not found");

    #endregion

    #region Media related exceptions
    public static BadRequestException DirectoryRequired()
       => new(CommonErrorCodes.DirectoryRequired, "Directory is required");

    public static BadRequestException FileNameRequired()
        => new(CommonErrorCodes.FileNameRequired, "File name is required");

    public static BadRequestException UnsupportedFileType()
        => new(CommonErrorCodes.UnsupportedFileType, "Unsupported file type");

    public static BadRequestException InvalidFileName()
        => new(CommonErrorCodes.InvalidFileName, "Invalid file name");

    public static BadRequestException OnlyImagesAllowed()
        => new(CommonErrorCodes.OnlyImagesAllowed, "Only image files are allowed");

    #endregion

    public static BadRequestException YourTrialPeriodHasExpired()
   => new(CommonErrorCodes.YourTrialPeriodHasExpired, "Your trial period has expired. Please contact the developer to activate your license.");

}