using System.ComponentModel.DataAnnotations;
using Homies.Data;

namespace Homies.Models
{
    public class TypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataConstants.RequireErrorMessage)]
        [StringLength(DataConstants.TypeNameMaxLength, MinimumLength = DataConstants.TypeNameMinLength, ErrorMessage = DataConstants.StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
