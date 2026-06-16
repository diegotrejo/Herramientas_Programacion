using Api.Consummer;
using MiApp.UTN.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiApp.MVC.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: EmpleadosController
        public ActionResult Index()
        {
            var data = Crud<Empleado>.ReadAll();
            return View(data);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(string id)
        {
            var data = Crud<Empleado>.ReadById(id);
            return View(data);
        }

        private void LeerListasDatos()
        {
            var listaPersonas = Crud<Persona>.ReadAll();
            var listaCargos = Crud<Cargo>.ReadAll();

            ViewBag.selectListPersonas = listaPersonas.Select(p =>
                new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Id} - {p.Apellido} {p.Nombre}"
                })
                .OrderBy(i => i.Text)
                .ToList();

            ViewBag.selectListCargos = listaCargos.Select(c =>
                new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .OrderBy(i => i.Text)
                .ToList();
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            LeerListasDatos();
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado data)
        {
            try
            {
                Crud<Empleado>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(data);
            }
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(string id)
        {
            var data = Crud<Empleado>.ReadById(id);
            LeerListasDatos();
            return View(data);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Empleado data)
        {
            try
            {
                Crud<Empleado>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(data);
            }
        }

        // GET: EmpleadosController/Delete/5
        public ActionResult Delete(string id)
        {
            var data = Crud<Empleado>.ReadById(id);
            LeerListasDatos();
            return View(data);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Empleado data)
        {
            try
            {
                Crud<Empleado>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ViewData["Error"] = ex.Message;
                return View(data);
            }
        }
    }
}
