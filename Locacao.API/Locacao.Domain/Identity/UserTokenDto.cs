namespace Locacao.Domain.Identity
{
    public class UserTokenDto
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<ClaimDto>? Claims { get; set; }
    }
}
