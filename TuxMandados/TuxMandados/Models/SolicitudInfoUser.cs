using System;
using System.Collections.Generic;
using System.Text;

namespace TuxMandados.Models
{
   public class SolicitudInfoUser
    {
        public Int64 id { get; set; }
        public string usuario { get; set; }
        public string token { get; set; }
        public Int64 rol { get; set; }
    }
}
