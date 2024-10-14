using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public interface IAccountService
    {
        bool ValidateUser(string username, string password);
    }
}
