using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProvaAvonale.Domain.Entities
{
    public class Repositorio
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("full_name")]
        public string NomeCompleto { get; set; }

        [JsonProperty("private")]
        public string Privado { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("description")]
        public string Descricao { get; set; }

        [JsonProperty("languages_url")]
        public string LanguagesUrl { get; set; }
        
        [JsonProperty("linguagens")]
        public IEnumerable<Linguagem> Linguagens { get; set; }

        [JsonProperty("contributors_url")]
        public string ContributorsUrl { get; set; }

        [JsonProperty("updated_at")] 
        public DateTime DataAtualizacao { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty("isFavorito")]
        public bool IsFavorito { get; set; }

        [JsonProperty("contribuidores")]
        public IEnumerable<Contribuidor> Contribuidores { get; set; }
    }
}
