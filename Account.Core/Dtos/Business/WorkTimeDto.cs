using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business
{
    public class WorkTimeDto
    {
        public DayOfWeek Day { get; set; }

        // Specifies custom JSON serialization for TimeOnly
        //[JsonConverter(typeof(TimeOnlyConverter))] 
        public TimeSpan Start { get; set; }

        // Specifies custom JSON serialization for TimeOnly
        //[JsonConverter(typeof(TimeOnlyConverter))] 
        public TimeSpan End { get; set; }

        public bool IsValid()
        {
            // Example validation logic: Start time must be before end time
            return Start < End;
        }
    }
}
