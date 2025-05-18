using AspNetCoreGeneratedDocument;
using capaEntidad;
using capaLogica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sistemaVentas8.Models;

namespace sistemaVentas8.Controllers
{
    public class MantenedorClienteController : Controller
    {
        public IActionResult ListarCliente()
        {
            List<EntCliente> lista = LogCliente.Instancia.ListarCliente();
            return View(lista);
        }

        [HttpGet]
        public IActionResult InsertarCliente()
        {
            return View(); //Esto va a llamar a la vistar InsertarCliente
        }

        public IActionResult EditarCliente(int idCliente)
        {
            try
            {
                var cliente = LogCliente.Instancia.BuscarCliente(idCliente);

                if (cliente == null) {
                    TempData["Error"] = "Cliente no encontrado.";
                    return RedirectToAction("ListarCliente");
                }
                return View(cliente);
            }
            catch (Exception ex) {
                ViewBag.Error = $"Ocurrió un error al buscar el cliente: {ex.Message}";
                return RedirectToAction("ListarCliente");
            }
        }

        [HttpPost]
        public IActionResult InsertarCliente(EntCliente ec)
        {
            if (ModelState.IsValid)
            {
                bool respuesta = LogCliente.Instancia.InsertarCliente(ec);
                if (respuesta)
                {
                    return RedirectToAction("ListarCliente");
                }
                else
                {
                    ViewBag.Error = "No se pudo insertar el cliente. Verifica los datos.";
                }
            }
            else
            {
                ViewBag.Error = "Los datos no son válidos.";
            }
            return View(ec);
        }
        [HttpPost]
        public IActionResult EditarCliente(EntCliente entCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool actualizado = LogCliente.Instancia.EditarCliente(entCliente);
                    if (actualizado)
                    {
                        TempData["Success"] = "Cliente actualizado correctamente.";
                        return RedirectToAction("ListarCliente");
                    }
                    else
                    {
                        ViewBag.Error = "No se pudo actualizar el cliente. Verifica los datos.";
                    }
                }
                else
                {
                    ViewBag.Error = "Los datos proporcionados no son válidos.";
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = $"Error al actualizar el cliente: {e.Message}";
            }
            return View(entCliente);

        }
    }
}
