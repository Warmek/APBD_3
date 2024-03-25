using System;
using System.Diagnostics.CodeAnalysis;
using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validator;

public class ValidatorFactory : IValidatorFactory
{
    public IUserCredit _UserCredit { get; set; }
    public ValidatorFactory(IUserCredit userCredit)
    {
        _UserCredit = userCredit;
    }
    
    public ClientValidator Create(Client client)
    {
        try
        {
            return (ClientValidator)Activator.CreateInstance(
                Type.GetType($"LegacyApp.Core.Validator.Clients.{client.Name}Validator"), new object[] { _UserCredit });
        }
        catch
        {
            return new OtherClientValidator(_UserCredit);
        }
        
    }
}