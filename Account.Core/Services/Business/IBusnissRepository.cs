using Account.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Business
{
    public interface IBusnissRepository
    {
        Task<IReadOnlyList<BusinessResponse>> GetAllBusinessesWithCategoryIdAsync(Guid Id);

    }
}
