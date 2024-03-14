using Account.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business.Response
{
    public class BusnissReponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string NameAR { get; set; }
        [Required]
        public string DescriptionAR { get; set; }
        public string? NameENG { get; set; }
        public string? DescriptionENG { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public ReviewSummary ReviewSummary { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Distance { get; set; }
    }
}
