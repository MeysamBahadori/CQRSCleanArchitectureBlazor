namespace Mc2.CrudTest.Common;

public class AppConest
{
    //API
    public const string ErrorMessage_Internal_Server_Error_Message = "Internal Server Error";
    public const string ErrorType_Internal_Server = "Internal server";
    public const string ErrorType_Domain_Data = "Domain data";
    public const string ErrorType_BusinessRuleValidation = "Business rule validation";
    public const string ErrorMessageFormat_EntityNotFoundException = "{0} entity with Id <{1}> not found";

    //Domain
    public const string ErrorMessage_CustomerUniqueEmailRule = "A customer with such an email already exists";
    public const string ErrorMessage_ValidPhoneNumberRule = "The phone number is not valid or not match with country code.";


}
