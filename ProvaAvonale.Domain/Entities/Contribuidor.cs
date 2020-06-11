using Newtonsoft.Json;

namespace ProvaAvonale.Domain.Entities
{
    public class Contribuidor
    {
        public string Login { get; set; }

        [JsonProperty("site_admin")]
        public string Admin { get; set; }
        
        [JsonProperty("contributions")]
        public int Contribuicoes { get; set; }
    }
}
