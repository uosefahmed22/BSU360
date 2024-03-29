﻿using Account.Apis.Errors;
using Account.Core.Models.Projectbusiness;
using Account.Core.Models.Related;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Account.Core.Models.ProjectBusiness
{
    public class Category : BaseEntity
    {

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Picture URL is required.")]
        public string PictureUrl { get; set; }

        [JsonIgnore]
        public ICollection<BusinessModel>? Businesses { get; set; }
    }
}
