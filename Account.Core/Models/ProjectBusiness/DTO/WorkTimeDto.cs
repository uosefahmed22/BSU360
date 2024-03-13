using Account.Core.Models.ProjectBusiness.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness.DTO
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
    }
}
