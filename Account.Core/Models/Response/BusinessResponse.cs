using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Account.Core.Models.Response
{
    public class BusinessResponse
    {
        public Guid Id { get; set; }

        public string NameAR { get; set; }

        public string DescriptionAR { get; set; }

        public string? NameENG { get; set; }

        public string? DescriptionENG { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public ReviewSummary ReviewSummary { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Distance { get; set; }
    }
}
