namespace Locacao.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; } = string.Empty;
        public int ExpirationTime { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string ValidOn { get; set; } = string.Empty;

    }
}
