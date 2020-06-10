using Newtonsoft.Json;

namespace ProvaAvonale.ApplicationService.Models
{
    public class RepositorioDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("full_name")]
        public string NomeCompleto { get; set; }


        [JsonProperty("private")]
        public string Privado { get; set; }
    }
}
