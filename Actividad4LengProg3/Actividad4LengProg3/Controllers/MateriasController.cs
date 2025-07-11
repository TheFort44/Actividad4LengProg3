using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Actividad4LengProg3.Controllers
{
    public class MateriasController : Controller
    {
        private readonly Actividad4LengProg3Context _context;

        public MateriasController(Actividad4LengProg3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(MateriaViewModel materias)
        {
            if (ModelState.IsValid)
            {
                _context.Materia.Add(materias);
                _context.SaveChanges();
                TempData["Mensaje"] = "Se registro la materia";
                return RedirectToAction("ListadoMaterias");
            }
            return View("Index", materias);
        }

        public IActionResult ListadoMaterias ()
        {
            var materias = _context.Materia.ToList();
            return View(materias);
        }
        [HttpGet]
        public IActionResult Editar(string codigomateria)
        {
            var materias = _context.Materia.FirstOrDefault(m => m.Codigo == codigomateria);
            if (materias == null)
            {
                TempData["Mensaje"] = "Esta materia no existe";
                return RedirectToAction("ListadoMaterias");

            }

            return View(materias);
        }
        [HttpPost]
        public IActionResult Editar(MateriaViewModel materia)
        {
            if (ModelState.IsValid)
            {
                var materiaActual = _context.Materia.FirstOrDefault(m => m.Codigo == materia.Codigo);

                if (materiaActual == null)
                {
                    TempData["Mensaje"] = "Esta asignatura no fue encontrada";
                    return RedirectToAction("ListadoMaterias");
                }

                materiaActual.Nombre = materia.Nombre;
                materiaActual.Creditos = materia.Creditos;
                materiaActual.Carrera = materia.Carrera;

                _context.Update(materiaActual);
                _context.SaveChanges();

                TempData["Mensaje"] = "Edicion Correcta";
                return RedirectToAction("ListadoMaterias");

            }
            return View(materia);
        }

        public IActionResult Eliminar(string CodigoMateria)
        {
            var materias = _context.Materia.FirstOrDefault(m => m.Codigo == CodigoMateria);
            if (materias != null)
            {
                _context.Materia.Remove(materias);
                _context.SaveChanges();
                TempData["Mensaje"] = "Esta asignatura fue eliminada";
                return RedirectToAction("ListadoMaterias");
            }
            return View(materias);
        }

    }
}
