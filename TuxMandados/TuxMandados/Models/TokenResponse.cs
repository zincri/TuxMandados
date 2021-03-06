﻿using System;
namespace TuxMandados.Models
{
    using System;
    using Newtonsoft.Json;
    public class TokenResponse
    {
        #region Properties
        [JsonProperty(PropertyName = "resultado")]
        public object Resultado { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "IDCOR")]
        public Int64 IDCOR { get; set; }

        [JsonProperty(PropertyName = "IDUsuario")]
        public Int64 IDUsuario { get; set; }

        [JsonProperty(PropertyName = "Rol")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }
        /*
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = ".issued")]
        public DateTime Issued { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        public DateTime Expires { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }
        */
        #endregion
    }
}
