namespace RaquunProject.DataAccess.DTOs
{
    public class AddUpdateCountryDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Capital { get; set; }
        public string? PhoneCode { get; set; }
        public int? Surface { get; set; }
        public int? Population { get; set; }
    }
}
