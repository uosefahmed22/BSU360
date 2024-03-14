using Account.Core.Dtos.Business;
using Account.Core.Models.ProjectBusiness;
using Account.Core.Services.Business;
using Account.Reposatory.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Buisness
{
    public class WorkTimeService : IWorkTimeService
    {
        private readonly BusnissDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        public WorkTimeService(BusnissDbContext dbContext, IDateTimeProvider dateTimeProvider)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }

        public Expression<Func<WorkTime, bool>> IsActive =>
       wt => wt.Day == _dateTimeProvider.Now.DayOfWeek &&
             wt.StartAsTimeOnly <= _dateTimeProvider.CurrentTime &&
             wt.EndAsTimeonly > _dateTimeProvider.CurrentTime;
        public async Task Add(WorkTimeDto workTime, Guid busnissId)
        {
            if (workTime == null)
            {
                throw new ArgumentNullException(nameof(workTime));
            }

            var wt = new WorkTime
            {
                Day = workTime.Day,
                Start = workTime.Start,
                End = workTime.End,
                BusinessId = busnissId
            };

            _dbContext.WorkTime.Add(wt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(WorkTime workTime)
        {
            if (workTime == null)
            {
                throw new ArgumentNullException(nameof(workTime));
            }

            _dbContext.WorkTime.Remove(workTime);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(WorkTime workTime)
        {
            if (workTime == null)
            {
                throw new ArgumentNullException(nameof(workTime));
            }

            _dbContext.WorkTime.Update(workTime);
            await _dbContext.SaveChangesAsync();
        }
    }
}
