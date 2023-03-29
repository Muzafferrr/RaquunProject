namespace RaquunProject.DTOs
{
    public class AddUpdateCityDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? PhoneCode { get; set; }
        public int? PlateCode { get; set; }
        public int? Surface { get; set; }
        public int? Population { get; set; }
        public string? Mayor { get; set; }
        public int CountryId { get; set; }
    }
}
