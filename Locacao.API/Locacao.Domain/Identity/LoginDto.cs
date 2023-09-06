namespace Locacao.Domain.Identity
{
    public class LoginDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
        public UserTokenDto? UserToken { get; set; }
    }
}
