using Account.Apis.Errors;
using Account.Core.Services.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    public class BusinessController : ApiBaseController
    {
        private readonly IBusnissRepository _busnissRepository;

        public BusinessController(IBusnissRepository busnissRepository)
        {
            _busnissRepository = busnissRepository;
        }
        
    }
}
