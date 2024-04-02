using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validator;

public class VeryImportantClientValidator : ClientValidator
{
    public VeryImportantClientValidator(IUserCredit userCredit) : base(userCredit)
    {
    }

    public override bool validateClient(ref User user)
    {
        user.HasCreditLimit = false;

        return !(user.HasCreditLimit && user.CreditLimit < 500);
    }
}