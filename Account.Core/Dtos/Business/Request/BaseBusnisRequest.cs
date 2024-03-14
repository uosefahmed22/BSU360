using Account.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business.Request
{
    public record BusnisRequest(Guid CategoryId) : BaseBusnisRequest;

    public record BusinessUpdateRequest(Guid Id) : BaseBusnisRequest;

    public abstract record BaseBusnisRequest
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string About { get; set; }

        public LocationDto Location { get; set; }

        [ListSize(maxSize: 7, minSize: 1, ErrorMessage = "WorkTime must have between 1 and 7 items.")]
        public List<WorkTimeDto> WorkTime { get; set; } = new List<WorkTimeDto>();

        public ContactDto ContactInfo { get; set; }
    }

}
