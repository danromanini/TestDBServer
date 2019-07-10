using Newtonsoft.Json;

namespace DaniloTest.Models.Requests
{
    public class LancamentoRequest
    {
        [JsonProperty(PropertyName = "contaDebido")]
        public int ContaDebido { get; set; }

        [JsonProperty(PropertyName = "contaCredito")]
        public int ContaCredito { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public decimal Valor { get; set; }

    }
}
