namespace Kodlama.io.Devs.Application.Features.Authentications.Dtos
{
    public class LoggedUserDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
