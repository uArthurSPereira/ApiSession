using System;

namespace ApiSession.Models.Response
{
    public class FilmeResponce
    {
        public int Id { get; set; }
        public string Filme { get; set; }
        public string Genero { get; set; }
        public int? Duracao { get; set; }
        public decimal? Avaliacao { get; set; }
        public bool Disponivel { get; set; }
        public DateTime Lancamento { get; set; }
    }
}