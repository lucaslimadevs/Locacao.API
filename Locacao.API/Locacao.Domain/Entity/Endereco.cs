namespace Locacao.Domain.Entity
{
    public class Endereco : Entity
    {
        public string Rua { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public Guid IdCidade { get; set; }
        public Guid IdCliente { get; set; }


        public virtual Cidade? Cidade { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
