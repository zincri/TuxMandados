using System;
using Newtonsoft.Json;

namespace TuxMandados.Models
{
    public class Ubicacion
    {
        [JsonProperty(PropertyName = "latitud")]
        public double Latitud { get; set; }

        [JsonProperty(PropertyName = "longitud")]
        public double Longitud { get; set; }
    }
}
