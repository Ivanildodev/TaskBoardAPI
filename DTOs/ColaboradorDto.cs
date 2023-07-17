namespace TaskBoardAPI.DTOs
{
    public class ColaboradorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int CargoId { get; set; }
        public bool Situacao { get; set; }
        public string Linkedin { get; set; }
    }
}
