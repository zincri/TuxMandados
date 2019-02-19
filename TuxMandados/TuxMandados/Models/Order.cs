using System;
namespace TuxMandados.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class Order //MODELO DE EL PEDIDO
    {
        //    -- CAMPOS TEMPORALES --
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "hora")]
        public string Hora { get; set; }

        [JsonProperty(PropertyName = "atendido")]
        public bool Atendido { get; set; }
        //    -- CAMPOS TEMPORALES --

        [JsonProperty(PropertyName = "id")]
        public bool ID { get; set; }

        [JsonProperty(PropertyName = "hora_pedido")]
        public TimeSpan? Hora_Pedido { get; set; }

        [JsonProperty(PropertyName = "hora_entregado")]
        public TimeSpan? Hora_Entregado { get; set; }

        [JsonProperty(PropertyName = "hora_entregado")]
        public string Estado { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty(PropertyName = "tiempo_entrega")]
        public string Tiempo_Entrega { get; set; }

        [JsonProperty(PropertyName = "costo")]
        public decimal Costo { get; set; }

        [JsonProperty(PropertyName = "numero_guia")]
        public int Numero_Guia { get; set; }

        [JsonProperty(PropertyName = "observaciones")]
        public string Observaciones { get; set; }

        [JsonProperty(PropertyName = "fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty(PropertyName = "puntuacion")]
        public float? Puntuacion { get; set; }

        [JsonProperty(PropertyName = "ubicacion")]
        public int Ubicacion { get; set; }

        [JsonProperty(PropertyName = "cliente")]
        public int? Cliente { get; set; }

        [JsonProperty(PropertyName = "repartidor")]
        public int? Repartidor { get; set; }
    }
}
