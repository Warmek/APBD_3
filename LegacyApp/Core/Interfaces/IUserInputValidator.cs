using System;

namespace LegacyApp.Core.Interfaces;

public interface IUserInputValidator
{
    public bool ValidateUserName(string firstName, string lastName);
    public bool ValidateUserEmail(string email);
    public bool ValidateUserAge(DateTime dateOfBirth);
}