using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Master.Datos;
using Master.Models;
using Master.Models.ViewModel;

namespace Master.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        Venta venta = new Venta();
        public ActionResult Index()
        {
            
            IEnumerable<ListaVentaViewModel> lista = venta.ConsultarVentas();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Venta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaVenta(VentaViewModel model)
        {

            int ventaID;
            int detalleResult;
            Venta venta = new Venta();
         
                ventaID = venta.CreateVenta(model);
                foreach (var item in model.Conceptos)
                {
                    Detalle detalle = new Detalle();
                    detalle.VentaID = ventaID;
                    detalle.ProductoID = item.ProductoID;
                    detalle.Precio = item.Precio;
                    detalle.Cantidad = item.Cantidad;

                    venta.CrearDetalle(detalle);                    
                }

            return RedirectToAction("Index");
        }

        // Obtener Un solo cliente mediante ajax
        [HttpGet]
        public JsonResult GetClientById(string id)
        {
            GetSingleClient client = new GetSingleClient();

            var model = client.GetClient(id);                        
            var json = JsonConvert.SerializeObject(model);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductById(int id)
        {
            GetSingleProduct product = new GetSingleProduct();

            var model = product.GetProduct(id);
            var json = JsonConvert.SerializeObject(model);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Reporte()
        {
            return View();
        }

        
    }
}