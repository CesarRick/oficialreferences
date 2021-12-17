using Master.Datos;
using Master.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Master.Controllers
{
    public class ClienteController : Controller
    {

        Cliente client = new Cliente();
        // GET: Cliente
        public ActionResult Index()
        {
            IEnumerable<ClientModel> lista = client.Consultar();
            return View(lista);
        }

        // Crear Cliente
        [HttpGet]
        public ActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClient(ClientModel model)
        {            
            client.CreateClient(model);
            return View("CreateClient", model);

        }

        // Editar Cliente
        [HttpGet]
        public ActionResult EditClient(int id)
        {            
            var model = client.EditClient(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditClient(ClientModel model)
        {
            client.EditClientById(model);
            return Redirect(Url.Content("~/Cliente/"));
        }
    }
}