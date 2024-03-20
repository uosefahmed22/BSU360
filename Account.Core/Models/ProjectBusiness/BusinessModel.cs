using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.ProjectBusiness;
using Account.Core.Models.ProjectBusiness.Contacts;
using Account.Core.Models.ProjectBusiness.Related;

namespace Account.Core.Models.Projectbusiness
{
    public class BusinessModel : BaseEntity
    {
        [Required(ErrorMessage = "Name in Arabic is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name in Arabic must be between 3 and 100 characters.")]
        public string NameAR { get; set; }
        [StringLength(100, ErrorMessage = "Name in English cannot exceed 100 characters.")]
        public string? NameENG { get; set; }
        [Required(ErrorMessage = "Description in Arabic is required.")]
        public string AboutAR { get; set; }
        public string? AboutENG { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? AlbumUrl { get; set; }
        public virtual Category? Category { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Address { get; set; }
        public int WorkStartHour { get; set; }
        public int WorkEndHour { get; set; }
        public int WorkingDays { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; } = new List<Holiday>();
        public virtual ICollection<PhoneNumbers> Contacts { get; set; } = new List<PhoneNumbers>();
        public ICollection<Rating> BusinessRatings { get; set; } = new List<Rating>();
        public ICollection<Review> BusinessReviews { get; set; } = new List<Review>();
        public ICollection<Favorite> BusinessFavorites { get; set; } = new List<Favorite>();

        ///I commented them for Testing
        ///[Required(ErrorMessage = "User ID is required.")]
        ///public Guid UserId { get; set; }
        ///[Required(ErrorMessage = "Category ID is required.")]
        ///[ForeignKey("Category")]
        ///public Guid CategoryId { get; set; }
    }
}