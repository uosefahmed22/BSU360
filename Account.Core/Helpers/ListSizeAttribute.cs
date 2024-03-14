using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Helpers
{
    [AttributeUsage(AttributeTargets.Property
    | AttributeTargets.Field
    | AttributeTargets.Parameter,
    AllowMultiple = false)]
    public class ListSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;
        private readonly int _minSize;
        private string? _errorMessage;

        public ListSizeAttribute(
            int maxSize,
            int minSize = 0,
            string? errorMessage = null)
        {
            if (minSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minSize), "Minimum size cannot be negative.");
            }

            if (maxSize < minSize)
            {
                throw new ArgumentException("Maximum size cannot be less than minimum size.");
            }

            _maxSize = maxSize;
            _minSize = minSize;

            _errorMessage = errorMessage ?? $"The {{0}} size must be between {_minSize} and {_maxSize}.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IList list && (list.Count > _maxSize || list.Count < _minSize))
            {
                string errorMessage = string.Format(_errorMessage!, validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
