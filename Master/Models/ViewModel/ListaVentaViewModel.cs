using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master.Models.ViewModel
{
    public class ListaVentaViewModel
    {
        public int VentaID { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public decimal Total { get; set; }
    }
}