using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Actividad4LengProg3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly Actividad4LengProg3Context _context;

        public CalificacionesController(Actividad4LengProg3Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Estudiantes = _context.Estudiante
            .Select(e => new SelectListItem
            {
                Value = e.Matricula,
                Text = e.Matricula + " - " + e.Nombre + " - " + e.Carrera
            }).ToList();

            ViewBag.Materias = _context.Materia
            .Select(m => new SelectListItem
            {
                Value = m.Codigo,
                Text = m.Codigo + " - " + m.Nombre
            }).ToList();

            return View(new CalificacionViewModel());
        }


        [HttpPost]
        public IActionResult Calificar(CalificacionViewModel calificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Calificacion.Add(calificacion);
                _context.SaveChanges();
                TempData["Mensaje"] = "Calificacion Publicada";
                return RedirectToAction("ListadoEstudiantes");
            }
            return View("Index", calificacion);
        }

        public IActionResult Lista()
        {
            var calificacion = _context.Calificacion.ToList();
            return View(calificacion);
        }

        [HttpGet]
        public IActionResult Editar(string idcalificacion)
        {
            var calificacion = _context.Calificacion.FirstOrDefault(c => c.Id.ToString() == idcalificacion);
            if (calificacion == null)
            {
                TempData["Mensaje"] = "Esta calificacion no existe";
                return RedirectToAction("ListadoEstudiantes");
            }
            return View(calificacion);
        }

        [HttpPost]
        public IActionResult Editar(CalificacionViewModel calificacion)
        {
            if (!ModelState.IsValid)
            {
                return View(calificacion);
            }
            var calificacionActual = _context.Calificacion.FirstOrDefault(c => c.Id == calificacion.Id);
            if (calificacionActual == null)
            {
                TempData["Mensaje"] = "Esta calificacion no existe";
                return RedirectToAction("ListadoEstudiantes");
            }

            calificacionActual.Nota = calificacion.Nota;

            _context.Update(calificacionActual);
            _context.SaveChanges();

            TempData["Mensaje"] = "Calificacion Corregida";
            return RedirectToAction("ListadoEstudiantes");
        }

        public IActionResult Eliminar(int num)
        {
            var calificacion = _context.Calificacion.FirstOrDefault(c => c.Id == num);
            if (calificacion != null)
            {
                _context.Calificacion.Remove(calificacion);
                _context.SaveChanges();
                TempData["Mensaje"] = "Calificacion eliminada";
                return RedirectToAction("ListadoEstudiantes");
            }
            return View(calificacion);
        }
    }
}
