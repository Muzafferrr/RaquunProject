using System.ComponentModel.DataAnnotations;

namespace RaquunProject.DataAccess.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        [MaxLength(50, ErrorMessage = "Country name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = "Country description cannot exceed 250 characters.")]
        public string? Description { get; set; }

        [MaxLength(50, ErrorMessage = "Capital city cannot exceed 50 characters.")]
        public string? Capital { get; set; }
        [MaxLength(50, ErrorMessage = "Phone code cannot exceed 50 characters.")]
        public string? PhoneCode { get; set; }
        public int? Surface { get; set; }
        public int? Population { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
