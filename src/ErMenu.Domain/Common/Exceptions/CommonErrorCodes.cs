namespace ErMenu.Domain.Common.Exceptions;

public static class CommonErrorCodes
{
    #region Address related error codes
    public const string AddressRequired = "ADDRESS_REQUIRED"; 
    #endregion

    #region Phone related error codes
    public const string PhoneNumberRequired = "PHONE_NUMBER_REQUIRED";
    public const string InvalidPhoneNumber = "INVALID_PHONE_NUMBER";
    public const string PhoneNumberCountryCodeRequired = "PHONE_NUMBER_COUNTRY_CODE_REQUIRED";
    public const string PhoneMustStartWithPlusAndCountryCode = "PHONE_MUST_START_WITH_PLUS_AND_COUNTRY_CODE";
    public const string PhoneMustContainDigitsOnly = "PHONE_MUST_CONTAIN_DIGITS_ONLY";
    public const string InvalidSaudiNumber = "INVALID_SAUDI_NUMBER";
    public const string InvalidEgyptNumber = "INVALID_EGYPT_NUMBER";
    public const string InvalidYemenNumber = "INVALID_YEMEN_NUMBER";
    public const string InvalidMoroccoNumber = "INVALID_MOROCCO_NUMBER";
    public const string UnsupportedCountryCode = "UNSUPPORTED_COUNTRY_CODE";
    #endregion

    #region Full name related error codes
    public const string FullNameRequired = "FULL_NAME_REQUIRED";
    public const string InvalidFullName = "INVALID_FULL_NAME";
    public const string FirstNameRequired = "FIRST_NAME_REQUIRED";
    public const string InvalidFirstName = "INVALID_FIRST_NAME";
    public const string LastNameRequired = "LAST_NAME_REQUIRED";
    public const string InvalidLastName = "INVALID_LAST_NAME";
    #endregion

    #region Email related exceptions; 

    public const string EmailRequired = "EMAIL_REQUIRED";
    public const string InvalidEmailFormat = "INVALID_EMAIL_FORMAT";
    public const string EmailTooLong = "EMAIL_TOO_LONG";

    #endregion

    #region Soft delete related error codes
    public const string EntityNotFound = "ENTITY_NOT_FOUND";
    public const string EntityAlreadyDeleted = "ENTITY_ALREADY_DELETED";
    public const string EntityNotDeleted = "ENTITY_NOT_DELETED";
    public const string EntityAlreadyExists = "ENTITY_ALREADY_EXISTS";
    #endregion

    #region Media related error codes
    public const string MediaAssetRequired = "MEDIA_ASSET_REQUIRED";
    public const string DirectoryRequired = "MEDIA_DIRECTORY_REQUIRED";
    public const string FileNameRequired = "MEDIA_FILE_NAME_REQUIRED";
    public const string UnsupportedFileType = "MEDIA_UNSUPPORTED_FILE_TYPE";
    public const string InvalidFileName = "MEDIA_INVALID_FILE_NAME";
    public const string OnlyImagesAllowed = "MEDIA_ONLY_IMAGES_ALLOWED";
    #endregion

    #region Password related error codes
    public const string PasswordRequired = "PASSWORD_REQUIRED";
    public const string ConfirmPasswordRequired = "CONFIRM_PASSWORD_REQUIRED";
    public const string PasswordsDoNotMatch = "PASSWORDS_DO_NOT_MATCH";
    public const string PasswordTooShort = "PASSWORD_TOO_SHORT";
    public const string PasswordTooLong = "PASSWORD_TOO_LONG";
    public const string PasswordMustContainUppercase = "PASSWORD_MUST_CONTAIN_UPPERCASE";
    public const string PasswordMustContainLowercase = "PASSWORD_MUST_CONTAIN_LOWERCASE";
    public const string PasswordMustContainNumber = "PASSWORD_MUST_CONTAIN_NUMBER";
    public const string PasswordMustContainSpecialCharacter = "PASSWORD_MUST_CONTAIN_SPECIAL_CHARACTER";
    #endregion
}