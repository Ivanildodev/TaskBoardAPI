namespace TaskBoardAPI.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }

        protected Cargo() { }

        public Cargo(string nome, string descricao, bool situacao)
        {
            Nome = nome;
            Descricao = descricao;
            Situacao = situacao;
        }
    }
}
