using Account.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories
{
    public class AccountService : IAccountService
    {
        public AccountService()
        {
            
        }
        public Task<string> RegisterAsync(string Email, Func<string, string, string> generateCallBackUrl)
        {
            
        }
    }
}
