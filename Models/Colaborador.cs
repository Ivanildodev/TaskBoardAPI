namespace TaskBoardAPI.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int CargoId { get; set; }
        public bool Situacao { get; set; }
        public string Linkedin { get; set; }
        public virtual Cargo Cargo { get; private set; }

        public Colaborador() { }

        public Colaborador(int id, string nome, string telefone, int cargoId, bool situacao, string linkedin)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CargoId = cargoId;
            Situacao = situacao;
            Linkedin = linkedin;
        }
    }
}
