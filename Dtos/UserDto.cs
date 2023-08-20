namespace BlazorAppLogin.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
