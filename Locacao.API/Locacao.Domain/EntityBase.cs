namespace Locacao.Domain.Entity
{
    public class Entity
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; } = true;

        public void Delete()
        {
            Ativo = false;
        }
    }
}
