
namespace TuxMandados.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;
    public class InfoUserResponse
    {
        [JsonProperty(PropertyName = "tipo")]
        public Int64 tipo { get; set; }
        [JsonProperty(PropertyName = "nombre")]
        public string nombre { get; set; }
        [JsonProperty(PropertyName = "apePat")]
        public string apePat { get; set; }
        [JsonProperty(PropertyName = "apeMat")]
        public string apeMat { get; set; }
        [JsonProperty(PropertyName = "fecha_nac")]
        public string fecha_nac { get; set; }
        [JsonProperty(PropertyName = "telefono")]
        public string telefono { get; set; }
        [JsonProperty(PropertyName = "ubicacion")]
        public Int64 ubicacion { get; set; }
    }
}
