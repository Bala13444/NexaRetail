using NexaRetail.Models;
using NexaRetail.Repositories;

namespace NexaRetail.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;

        public AuthenticationService()
        {
            _userRepository = new UserRepository();
        }

        public User Login(
            string userName,
            string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                return null;
            }

            User user =
                _userRepository.GetUser(
                    userName,
                    passwordHash);

            return user;
        }
    }
}