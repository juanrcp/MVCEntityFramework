using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCEntityFrameworkDAL.Modelo;
using Newtonsoft.Json;

namespace MVCEntityFramework.Controllers
{
    public class EmpleadosController : Controller
    {
        //Creamos objeto de la clase de la base de datos correspondiente a la configuracion.
        public MVCEntityFrameworkDAL.Modelo.DeveloferContext db = new DeveloferContext();

        public IActionResult Index()
        {
            //Recuperamos empleados de la base de datos
            var empleados = db.Empleados.ToList();

            //Añadimos un session para que no nos falle al sesion despues de la primera consulta.
            ViewBag.Nombre = empleados;

            return View(empleados); 
        }
    }
}
