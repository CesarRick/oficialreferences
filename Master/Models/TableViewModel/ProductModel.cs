using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master.Models.TableViewModel
{
    public class ProductModel
    {
        public int ProductoID { get; set; }        
        public string Nombre { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal Precio { get; set; }
    }
}