namespace TuxMandados.Models
{
    using System;
    public class SolicitudSetOrder
    {
        public Int64 IDCliente { get; set; }
        public Int64 IDUsuario { get; set; }
        //public Int64 IDOrder { get; set; }
        public Order Order { get; set; }

        #region Properties
        private object _result;
        public object Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private string _mensaje;
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
        private string _conexion;
        public string Conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
        private string _DatosJson;
        public string DatosJson
        {
            get { return _DatosJson; }
            set { _DatosJson = value; }
        }
        #endregion

    }
}
