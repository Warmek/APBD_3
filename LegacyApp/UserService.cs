using System;
using LegacyApp.Core.Interfaces;
using LegacyApp.Core.Validator;

namespace LegacyApp
{
    public class UserService
    {
        private IUserInputValidator _inputValidator;
        private IClientRepo _clientRepo;

        public UserService()
        {
            _inputValidator = new UserInputValidator();
            _clientRepo = new ClientRepository();
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_inputValidator.ValidateUserName(firstName, lastName))
                return false;
            if (!_inputValidator.ValidateUserEmail(email))
                return false;
            if (!_inputValidator.ValidateUserAge(dateOfBirth))
                return false;
            
            
            var client = _clientRepo.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

    }
}
