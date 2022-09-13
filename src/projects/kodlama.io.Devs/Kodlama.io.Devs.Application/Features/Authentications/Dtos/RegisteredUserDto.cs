namespace Kodlama.io.Devs.Application.Features.Authentications.Dtos
{
    public class RegisteredUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
