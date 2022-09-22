using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistroWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroWeb.Controllers
{
    public class HomeController : Controller
    {       

        public ActionResult Index()
        {
            Mantenimiento mant = new Mantenimiento();            
            return View(mant.LeerTodo());
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Alta()
        {
            return View();
        }        

        [HttpPost]
        public ActionResult Alta (IFormCollection dato) 
        {
            Mantenimiento mant = new Mantenimiento();
            
            Persona persona = new Persona();
            persona = mant.Leer(dato["dni"]);
            string confirm = persona.dni;
            if (confirm != null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                Persona pers = new Persona()
                {
                    dni = dato["dni"],
                    nombre = dato["nombre"],
                    domicilio = dato["domicilio"],
                    fecha = DateTime.Parse(dato["fecha"])
                };
                mant.Carga(pers);
                return RedirectToAction("Index");
            }            
        }        
        public ActionResult Baja (string dni)
        {            
            Mantenimiento mant = new Mantenimiento();
            mant.Borrar(dni);
            return RedirectToAction("Index");
        }
        public ActionResult Modificacion(string dni)
        {
            Mantenimiento mant = new Mantenimiento();
            Persona pers = new Persona();
            pers = mant.Leer(dni);
            return View(pers);
        }
        [HttpPost]
        public ActionResult Modificacion (IFormCollection form)
        {
            Mantenimiento mant = new Mantenimiento ();
            Persona pers = new Persona()
            {
                dni = form["dni"],
                nombre = form["nombre"],
                domicilio = form["domicilio"],
                fecha = DateTime.Parse(form["fecha"])
            };
            mant.Modificar(pers);
            return RedirectToAction("Index");
        }
    }
}
