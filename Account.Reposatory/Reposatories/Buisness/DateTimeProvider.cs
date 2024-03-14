using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Buisness
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;

        public TimeOnly CurrentTime => TimeOnly.FromDateTime(Now);
    }
}
