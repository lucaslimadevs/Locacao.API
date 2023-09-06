namespace Locacao.Domain.Entity
{
    public class Cidade : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
    }
}
