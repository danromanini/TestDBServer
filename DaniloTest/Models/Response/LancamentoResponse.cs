using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaniloTest.Models.Response
{
    public class LancamentoResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; } = false;

        public LancamentoResponse(bool retorno)
        {
            if (retorno)
            {
                Success = true;                
            }
        }
    }
}
