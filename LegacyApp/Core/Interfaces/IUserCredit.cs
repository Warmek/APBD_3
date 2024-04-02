using System;

namespace LegacyApp.Core.Interfaces;

public interface IUserCredit
{
    public int GetCreditLimit(string lastName, DateTime dateOfBirth);
}