
namespace TuxMandados.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;
    public class ValidCorreoResponse
    {
        #region properties
        [JsonProperty(PropertyName = "valido")]
        public int Valido { get; set; }
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        #endregion
    }
}
