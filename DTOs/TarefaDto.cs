namespace TaskBoardAPI.DTOs
{
    public class TarefaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CardId { get; set; }
        public int ResponsavelId { get; set; }
        public CardDto Card { get; set; }
    }
}
