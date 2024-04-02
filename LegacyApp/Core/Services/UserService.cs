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
            
            
            Client client = _clientRepo.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            ClientValidator validator = new ValidatorFactory(new UserCreditService()).Create(client);

            var isValid = validator.validateClient(ref user);

            if (isValid)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

    }
}
