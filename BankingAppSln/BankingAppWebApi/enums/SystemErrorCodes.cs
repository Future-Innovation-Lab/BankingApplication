namespace BankingAppWebApi.enums
{
    public enum SystemErrorCodes
    {
        CustomerNotValid,
        CustomerDuplicate,
        CustomerCreationFailed,
        AuthenticationFailed,
        BankAccountNotValid,
        BankAccountCreationFailed,
        BankAccountNotValidForTransaction,
        InsufficientFundsForTransaction
    }
}
