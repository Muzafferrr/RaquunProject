namespace RaquunProject.DataAccess.DTOs
{
    public class UserAuthenticationDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }
    }
}
