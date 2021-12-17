using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master.Models
{
    public class ClientModel
    {
        public int ClienteID { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}