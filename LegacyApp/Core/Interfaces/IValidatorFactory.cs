using LegacyApp.Core.Validator;

namespace LegacyApp.Core.Interfaces;

public interface IValidatorFactory
{
    public ClientValidator Create(Client client);
}