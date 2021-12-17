using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master.Models.ViewModel
{
    public class VentaViewModel
    {
        public int ClienteID { get; set; }
        public List<Detalle> Conceptos { get; set; }
    }

    public class Detalle
    {
        public int VentaID { get; set; }
        public int ProductoID { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }        
    }
}