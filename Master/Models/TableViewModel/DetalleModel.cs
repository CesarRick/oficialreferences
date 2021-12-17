using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master.Models.TableViewModel
{
    public class DetalleModel
    {
        public int DetalleID { get; set; }
        public int VentaID { get; set; }
        public int ProductoID { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
    }
}