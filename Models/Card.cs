namespace TaskBoardAPI.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Posicao { get; set; }
        public string Cor { get; set;}
        public virtual Tarefa Tarefa { get; set; }

        protected Card() { }

        public Card(string nome, int posicao, string cor)
        {
            Nome = nome;
            Posicao = posicao;
            Cor = cor;
        }
    }
}
