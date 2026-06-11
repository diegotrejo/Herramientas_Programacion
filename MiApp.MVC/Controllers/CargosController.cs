using Api.Consummer;
using MiApp.UTN.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiApp.MVC.Controllers
{
    public class CargosController : Controller
    {
        // GET: CargosController
        public ActionResult Index()
        {
            var cargos = Crud<Cargo>.ReadAll();
            return View(cargos);
        }

        // GET: CargosController/Details/5
        public ActionResult Details(string id)
        {
            var datos = Crud<Cargo>.ReadById(id);
            return View(datos);
        }

        // GET: CargosController/Create
        public ActionResult Create()
        {
            // devuelve vista SIN DATOS
            return View();
        }

        // POST: CargosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cargo data)
        {
            try
            {
                var nuevoCargo = Crud<Cargo>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CargosController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Crud<Cargo>.ReadById(id.ToString());
            return View(datos);
        }

        // POST: CargosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cargo datos)
        {
            try
            {
                Crud<Cargo>.Update( id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
                return View(datos);
            }
        }

        // GET: CargosController/Delete/5
        public ActionResult Delete(string id)
        {
            var datos = Crud<Cargo>.ReadById(id);
            return View(datos);
        }

        // POST: CargosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Cargo datos)
        {
            try
            {
                Crud<Cargo>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ViewData["error"] = ex.Message;
                return View(datos);
            }
        }
    }
}
