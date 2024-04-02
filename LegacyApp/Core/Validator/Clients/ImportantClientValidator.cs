using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validator;

public class ImportantClientValidator : ClientValidator
{
    public ImportantClientValidator(IUserCredit userCredit) : base(userCredit)
    {
    }

    public override bool validateClient(ref User user)
    {
        int creditLimit = _UserCredit.GetCreditLimit(user.LastName, user.DateOfBirth);
        creditLimit = creditLimit * 2;
        user.CreditLimit = creditLimit;

        return !(user.HasCreditLimit && user.CreditLimit < 500); ;
    }
}