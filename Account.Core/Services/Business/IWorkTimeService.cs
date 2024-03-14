using Account.Core.Dtos.Business;
using Account.Core.Models.ProjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Business
{
    public interface IWorkTimeService
    {
        Task Add(WorkTimeDto workTime, Guid busnissId);
        Expression<Func<WorkTime, bool>> IsActive { get; }
        Task Remove(WorkTime workTime);
        Task Update(WorkTime workTime);
    }
}
