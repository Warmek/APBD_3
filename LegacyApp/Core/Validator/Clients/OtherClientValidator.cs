using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validator;

public class OtherClientValidator : ClientValidator
{
    public OtherClientValidator(IUserCredit userCredit) : base(userCredit)
    {
    }

    public override bool validateClient(ref User user)
    {
        user.HasCreditLimit = true;
        int creditLimit = _UserCredit.GetCreditLimit(user.LastName, user.DateOfBirth);
        user.CreditLimit = creditLimit;

        return !(user.HasCreditLimit && user.CreditLimit < 500);
    }
}