
namespace TuxMandados.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;
    public class UserResponse
    {
        #region properties
        [JsonProperty(PropertyName = "idcli")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }
        #endregion
    }
}
