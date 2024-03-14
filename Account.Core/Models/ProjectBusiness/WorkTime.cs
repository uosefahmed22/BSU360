using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Dtos.Business;

namespace Account.Core.Models.ProjectBusiness
{
    public class WorkTime : BaseEntity
    {
        [Required(ErrorMessage = "Day of the week is required.")]
        public DayOfWeek Day { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        public TimeSpan Start { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        public TimeSpan End { get; set; }

        [Required(ErrorMessage = "Business ID is required.")]
        [ForeignKey("Business")]
        public Guid BusinessId { get; set; }

        // A method to convert DTOs to WorkTime entities
        public static IEnumerable<WorkTime> SetBusinessWorkTime(List<WorkTimeDto> request, Guid businessId)
        {
            foreach (WorkTimeDto dto in request)
            {
                yield return new WorkTime
                {
                    Day = dto.Day,
                    Start = dto.Start,
                    End = dto.End,
                    BusinessId = businessId
                };
            }
        }
        public TimeOnly StartAsTimeOnly => TimeOnly.FromTimeSpan(Start);
        public TimeOnly EndAsTimeonly => TimeOnly.FromTimeSpan(End);

    }
}
