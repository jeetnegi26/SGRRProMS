using Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRepositoryData;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateUser(string username, string password)
        {
            // Hash password if required before comparing
            var user = _userRepository.GetUserByUsername(username);
            if (user != null && user.HashPassword == password)
            {
                return true;
            }
            return false;
        }
    }
}
