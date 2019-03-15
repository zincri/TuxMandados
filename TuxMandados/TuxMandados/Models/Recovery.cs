using System;
using System.Collections.Generic;
using System.Text;

namespace TuxMandados.Models
{
   public class Recovery
    {
        private int _valido;

        public int Valido
        {
            get { return _valido; }
            set { _valido = value; }
        }
        private string _token;

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }


    }
}
