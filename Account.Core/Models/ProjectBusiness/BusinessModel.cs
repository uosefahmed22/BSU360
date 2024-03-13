using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.ProjectBusiness;

namespace Account.Core.Models.Projectbusiness
{
    public class BusinessModel:BaseEntity
    {
        // Multilingual properties
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

        public ICollection<Review>? Reviews { get; set; }

        //[Required(ErrorMessage = "User ID is required.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        // Navigation properties
        public virtual Category? Category { get; set; }

        public virtual Location? Location { get; set; }

        // Collections
        public virtual ICollection<WorkTime> WorkTimes { get; set; } = new List<WorkTime>();

        public virtual Contact? ContactInfo { get; set; }
    }
}
