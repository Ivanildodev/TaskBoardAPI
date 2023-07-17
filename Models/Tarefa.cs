namespace TaskBoardAPI.Models
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public int CardId { get; set; }
        public int ResponsavelId { get; set; }
        public virtual Card Card { get; set; }
        public virtual Colaborador Responsavel { get; set; }

        protected Tarefa() { }

        public Tarefa(string nome, int responsavelId, Card card) { 
            Nome = nome;
            Card = card;
            ResponsavelId = responsavelId;
        }
    }
}
