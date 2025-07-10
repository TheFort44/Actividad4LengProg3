using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Actividad4LengProg3.Controllers
{
    public class EstudianteController : Controller
    {
        private Actividad4LengProg3Context _context;

        public EstudianteController(Actividad4LengProg3Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel estudiantes)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiante.Add(estudiantes);
                _context.SaveChanges();
                TempData["Mensaje"] = "El estudiante fue registrado";
                return RedirectToAction("ListadoEstudiantes");
            }
            ;
            return View("Index", estudiantes);
        }

        public IActionResult ListadoEstudiantes()
        {
            var estudiantes = _context.Estudiante.ToList();
            return View(estudiantes);
        }

        [HttpGet]
        public IActionResult Editar(String matricula)
        {
            var estudiante = _context.Estudiante.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
            {
                TempData["Mensaje"] = "No existe el estudiante indicado";
                return RedirectToAction("ListadoEstudiantes");
            }
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Editar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                var EstudianteActual = _context.Estudiante.FirstOrDefault(e => e.Matricula == estudiante.Matricula);

                if (EstudianteActual == null)
                {
                    TempData["Mensaje"] = "Este estudiante no fue encontrado";
                    return RedirectToAction("ListadoEstudiantes");
                }

                EstudianteActual.Nombre = estudiante.Nombre;
                EstudianteActual.Matricula = estudiante.Matricula;
                EstudianteActual.Carrera = estudiante.Carrera;
                EstudianteActual.CorreoInstitucional = estudiante.CorreoInstitucional;
                EstudianteActual.Telefono = estudiante.Telefono;
                EstudianteActual.FechaNacimiento = estudiante.FechaNacimiento;
                EstudianteActual.Genero = estudiante.Genero;
                EstudianteActual.Turno = estudiante.Turno;
                EstudianteActual.TipoIngreso = estudiante.TipoIngreso;
                EstudianteActual.Becado = estudiante.Becado;
                EstudianteActual.PorcentajeBeca = estudiante.PorcentajeBeca;

                _context.Update(EstudianteActual);
                _context.SaveChanges();

                TempData["Mensaje"] = "Información actualizada";
                return RedirectToAction("ListadoEstudiantes");
            }

            return View(estudiante);
        }

        public IActionResult Eliminar(string matricula)
        {
            var estudiante = _context.Estudiante.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                _context.Estudiante.Remove(estudiante);
                _context.SaveChanges();
                TempData["Mensaje"] = "El estudiante fue eliminado";
                return RedirectToAction("ListadoEstudiantes");
            }
            return View(estudiante);
        }
    }
}
   