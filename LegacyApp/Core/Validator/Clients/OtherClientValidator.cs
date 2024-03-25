using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validator;

public class OtherClientValidator : ClientValidator
{
    public OtherClientValidator(IUserCredit userCredit) : base(userCredit)
    {
    }

    public override bool validateClient(Client client)
    {
        throw new System.NotImplementedException();
    }
}