﻿using System;
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

        [JsonProperty(PropertyName = "fecha")]
        public string Fecha { get; set; }

        [JsonProperty(PropertyName = "atendido")]
        public bool Atendido { get; set; }
        //    -- CAMPOS TEMPORALES --


    }
}
