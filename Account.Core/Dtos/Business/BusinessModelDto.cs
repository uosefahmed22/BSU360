using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business
{
    public class BusinessModelDto
    {
        public Guid Id { get; set; }
        public string NameAR { get; set; }
        public string? NameENG { get; set; }
        public string AboutAR { get; set; }
        public string? AboutENG { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? AlbumUrl { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Address { get; set; }
        public int WorkStartHour { get; set; }
        public int WorkEndHour { get; set; }
        public int WorkingDays { get; set; }
        public ICollection<Guid> HolidayIds { get; set; }
        public ICollection<Guid> ContactIds { get; set; }
        public ICollection<Guid> BusinessRatingIds { get; set; }
        public ICollection<Guid> BusinessReviewIds { get; set; }
        public ICollection<Guid> BusinessFavoriteIds { get; set; }
    }
}
