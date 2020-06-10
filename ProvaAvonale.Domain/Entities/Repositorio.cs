using System;

namespace ProvaAvonale.Domain.Entities
{
    public class Repositorio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public bool Privado { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Proprietario { get; set; }
    }
}
