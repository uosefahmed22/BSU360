using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Business.Request
{
    public record CategoryUpdateRequest : BaseCategoryRequest
    {
        public CategoryUpdateRequest(Guid id) : base(id)
        {
        }
    }

    public abstract record BaseCategoryRequest(Guid Id)
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Picture URL is required.")]
        public string PictureUrl { get; init; }
    }


}

