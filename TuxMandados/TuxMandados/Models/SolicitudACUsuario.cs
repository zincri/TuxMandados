using System;
using System.Collections.Generic;
using System.Text;

namespace TuxMandados.Models
{
   public class SolicitudACUsuario
    {
        public int opcion { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string ape_pat { get; set; }
        public string ape_mat { get; set; }
        public string direccion { get; set; }
        public string fecha { get; set; }
        public string telefono { get; set; }
        public decimal latitud { get; set; }
        public decimal longitud { get; set; }
        public bool cambioPass { get; set; }
        public int idloc { get; set; }
        public int idcli { get; set; }
        public int idusu { get; set; }
    }
}
