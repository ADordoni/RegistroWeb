using System;
using System.Collections.Generic;
using System.Web;

namespace RegistroWeb.Models
{
    public class Persona
    {
        public string nombre
        {
            get;
            set;
        }
        public string domicilio
        {
            get;
            set;
        }
        public DateTime fecha
        {
            get;
            set;
        }
        public string dni
        {
            get;
            set;
        }
    }
}
