using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validator;

public class ImportantClientValidator : ClientValidator
{
    public ImportantClientValidator(IUserCredit userCredit) : base(userCredit)
    {
    }

    public override bool validateClient(Client client)
    {
        throw new System.NotImplementedException();
    }
}