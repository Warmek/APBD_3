using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validator;

public class VeryImportantClientValidator : ClientValidator
{
    public VeryImportantClientValidator(IUserCredit userCredit) : base(userCredit)
    {
    }

    public override bool validateClient(Client client)
    {
        throw new System.NotImplementedException();
    }
}