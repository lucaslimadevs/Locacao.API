namespace Locacao.Domain.Entity
{
    public class Equipamento : Entity
    {
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal PrecoDiario { get; private set; }
        public decimal PrecoSemanal { get; private set; }
        public decimal PrecoMensal { get; private set; }

        public Equipamento(string nome, string? descricao, decimal precoDiario, decimal precoSemanal, decimal precoMensal)
        {
            Nome = nome;
            Descricao = descricao;
            PrecoDiario = precoDiario;
            PrecoSemanal = precoSemanal;
            PrecoMensal = precoMensal;
        }

        public void AtualizarInformacoes(string novoNome, string? novaDescricao, decimal novoPrecoDiario, decimal novoPrecoSemanal, decimal novoPrecoMensal)
        {
            Nome = novoNome;
            Descricao = novaDescricao;
            PrecoDiario = novoPrecoDiario;
            PrecoSemanal = novoPrecoSemanal;
            PrecoMensal = novoPrecoMensal;
        }
    }
}
    