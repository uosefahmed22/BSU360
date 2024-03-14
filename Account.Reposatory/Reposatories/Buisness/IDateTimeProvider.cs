using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Buisness
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        TimeOnly CurrentTime { get; }
    }
}
