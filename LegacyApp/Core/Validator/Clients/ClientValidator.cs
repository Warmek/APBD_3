using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validator;

public abstract class ClientValidator
{
    public IUserCredit _UserCredit { get; set; }

    public ClientValidator(IUserCredit userCredit)
    {
        _UserCredit = userCredit;
    }

    public abstract bool validateClient(ref User user);

}