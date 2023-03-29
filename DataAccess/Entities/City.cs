using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaquunProject.DataAccess.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [MaxLength(50, ErrorMessage = "City name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = "City description cannot exceed 250 characters.")]
        public string? Description { get; set; }

        public int? PlateCode { get; set; }
        public int? Population { get; set; }
        public int? Surface { get; set; }
        public string? PhoneCode { get; set; }
        public string? Mayor { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
